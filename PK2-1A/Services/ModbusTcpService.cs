﻿using EasyModbus;
using EasyModbus.Exceptions;
using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using belofor.Models;

namespace belofor.Services
{
    public delegate void ConnectedChanged(bool status);

    public class ModbusTcpService
    {
       // private readonly string ModbusClientIP = "127.0.0.1";
        private readonly string ModbusClientIP = "192.168.120.139";
       // private readonly string ModbusClientIP = "192.168.0.22";
        //private readonly string ModbusClientIP = "192.168.200.18";
        //private readonly int ModbusPort = 502;
        private readonly int ModbusPort = 502;

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        ConcurrentQueue<ModbusWriteItem> requestToWrite = new ConcurrentQueue<ModbusWriteItem>();


        public ConnectedChanged ConnectedChangedHandler;


        private readonly ModbusClient _modbusClient;
        private readonly ProcessData _processData;

        object locker = new object();

        public ModbusTcpService(ProcessDataTcp processData)
        {
            _processData = processData;

            _modbusClient = new ModbusClient(ModbusClientIP, ModbusPort);

            _modbusClient.ConnectedChanged += connectedChanged;
            _processData.RequestModbusWrite = requestModbusWrite;

        }

        public void Worker()
        {
            List<int> requestResult = new List<int>();

            try
            {
                if (_modbusClient.Connected)
                {
                    lock (locker)
                    {
                        if (!requestToWrite.IsEmpty)
                        {
                            ModbusWriteItem obj;
                            requestToWrite.TryDequeue(out obj);
                            if (obj.Distination == Distination.COIL)
                                _modbusClient.WriteSingleCoil(obj.Addr, (bool)(obj.Val));
                            else
                                _modbusClient.WriteMultipleRegisters(obj.Addr, (int[])obj.Val);

                        }
                        else
                        {
                            _processData.ModbusWriteCompleted = true;

                            _processData.DTS = DateTime.Now;

                            if (_processData.InputCount > 0)
                            {
                                requestResult.AddRange(_modbusClient.ReadDiscreteInputs(0, _processData.InputCount).ToIntList());
                                Thread.Sleep(50);
                            }
                            if (_processData.CoilCount > 0)
                            {
                                requestResult.AddRange(_modbusClient.ReadCoils(0, _processData.CoilCount).ToIntList());
                                Thread.Sleep(50);
                            }
                            if (_processData.InputRegisterCount > 0)
                            {
                                if (_processData.InputRegisterCount <= 123) 
                                    requestResult.AddRange(_modbusClient.ReadInputRegisters(0, _processData.InputRegisterCount).ToList());
                                else
                                {
                                    requestResult.AddRange(_modbusClient.ReadInputRegisters(0, 123).ToList());
                                    requestResult.AddRange(_modbusClient.ReadInputRegisters(123, _processData.InputRegisterCount - 123).ToList());
                                }
                                Thread.Sleep(50);
                            }
                            if (_processData.HoldigRegisterCount > 0)
                            {
                                if (_processData.HoldigRegisterCount <= 123)
                                    requestResult.AddRange(_modbusClient.ReadHoldingRegisters(0, _processData.HoldigRegisterCount).ToList());
                                else
                                {
                                    requestResult.AddRange(_modbusClient.ReadHoldingRegisters(0, 123).ToList());
                                    requestResult.AddRange(_modbusClient.ReadHoldingRegisters(123, _processData.HoldigRegisterCount - 123).ToList());
                                }

                                //requestResult.AddRange(_modbusClient.ReadHoldingRegisters(0, _processData.HoldigRegisterCount).ToList());
                                Thread.Sleep(50);
                            }
                        }
                    }
                }
                else
                    _modbusClient.Connect();
            }

            catch (ConnectionException ex)
            {
                //MethodBase.GetCurrentMethod().Name
                _logger.Error(ex, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
                //_logger.Error(ex, this.GetType().Name);
                _modbusClient.Disconnect();
            }

            catch (System.IO.IOException ex)
            {
                _logger.Error(ex, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
                _modbusClient.Disconnect();
            }

            catch (Exception ex)
            {

                _logger.Error(ex, this.GetType().Name + "." + MethodBase.GetCurrentMethod().Name);
                _modbusClient.Disconnect();
            }
            finally
            {
                var modbusCounts = _processData.InputCount + _processData.CoilCount + _processData.InputRegisterCount + _processData.HoldigRegisterCount;
                if (requestResult.Count != modbusCounts)
                {
                    int i = 0;//requestResult.Count;
                    while (i < modbusCounts)
                    {
                        requestResult.Add(0);
                        i++;
                    }
                }

                _processData.ExternalSet(requestResult.ToArray());

                requestResult.Clear();

            }

        }


        #region events
        private void requestModbusWrite(ModbusWriteItem item)
        {
            requestToWrite.Enqueue(item);
        }

        private void connectedChanged(object sender) => ConnectedChangedHandler?.Invoke((sender as ModbusClient).Connected ? true : false);

        public void AfterStop()
        {
            lock (locker)
            {
                // exit 
                _modbusClient.ConnectedChanged -= connectedChanged;

                if (_modbusClient.Connected)
                    _modbusClient.Disconnect();
            }

        }
        #endregion
    }

    public static class ArrayExtensions
    {
        public static List<int> ToIntList(this bool[] array)
        {
            List<int> result = new List<int>();
            foreach (var element in array)
            {
                result.Add(Convert.ToInt16(element));
            }
            return result;
        }
    }

}
