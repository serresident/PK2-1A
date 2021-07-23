using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using belofor.Attributes;
using belofor.Helpers;
using belofor.Models;
using belofor.Repositories;

namespace belofor.ViewModels
{
    public class JournalViewModel : BindableBase
    {
        private ObservableRangeCollection<JournalItem> journalItems;
        public ObservableRangeCollection<JournalItem> JournalItems
        {
            get { return journalItems; }
            set { SetProperty(ref journalItems, value); }
        }

        private ProcessDataTcp _pd;
        public ProcessDataTcp PD
        {
            get { return _pd; }
            set { SetProperty(ref _pd, value); }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public JournalViewModel(ProcessDataTcp pd, JournalRepository journalRepository)
        {
            PD = pd;
        }

        public void OnLoading()
        {
            //ShowMessage = "Wait please...";

            Task.Factory.StartNew(() =>
            {
                IsBusy = true; // Show busyindicator and ProgressRing

                var _journalItems = new List<JournalItem>();
                foreach (PropertyInfo prop in PD.GetType().GetProperties().Where(p => p.PropertyType.IsPrimitive && Attribute.IsDefined(p, typeof(JournalAttribute))))
                {
                    var attr = (JournalAttribute[])prop.GetCustomAttributes(typeof(JournalAttribute), false);
                    var message = attr[0].Message.Substring(0, attr[0].Message.IndexOf(">") - 1);
                    
                    _journalItems.Add(new JournalItem() { Message = message, Property = prop.Name });
                }

                //_journalItems.FirstOrDefault().
                //_journalItems.Add("1111", "2222");
                //_journalItems.Add("3333", "4444");
                JournalItems = new ObservableRangeCollection<JournalItem>(_journalItems);

                //Thread.Sleep(5000); // 5 seconds to see the animation (Here is a SQL insert)

                /// Hide ProgressRing only

                //ShowMessage = "Save complete.";

                //Thread.Sleep(2000); // 2 seconds to see "ShowMessage"

            }).ContinueWith(x =>
            {
                IsBusy = false; // hide busyindicator and ProgressRing

            }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
