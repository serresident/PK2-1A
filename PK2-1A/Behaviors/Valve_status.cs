﻿using AITSW.PCPANEL.WPF;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace belofor.Behaviors
{
    public class Valve_status : Behavior<ControlBase>
    {
        private OptionsBehavior handleControlBehavior;

        private Popup popupPanel;
        private Border openBorder;
        private Border closeBorder;
        private TextBlock openTextBlock;
        private TextBlock closeTextBlock;
        private Arrow open;
        private Arrow close;

        public static readonly DependencyProperty isOpenValveProperty = DependencyProperty.Register("isOpenValve", typeof(bool), typeof(Valve_status), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) => ((Valve_status)d).Update()));
        public bool isOpenValve
        {
            get { return (bool)GetValue(isOpenValveProperty); }
            set { SetValue(isOpenValveProperty, value); }
        }

        public static readonly DependencyProperty isCloseValveProperty = DependencyProperty.Register("isCloseValve", typeof(bool), typeof(Valve_status), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, (d, e) => ((Valve_status)d).Update()));
        public bool isCloseValve
        {
            get { return (bool)GetValue(isCloseValveProperty); }
            set { SetValue(isCloseValveProperty, value); }
        }

        private System.Windows.Controls.Primitives.PlacementMode placementMode = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
        public System.Windows.Controls.Primitives.PlacementMode PlacementMode
        {
            get { return placementMode; }
            set
            {
                placementMode = value;
            }
        }


        private int hspacing = -14; // сдвиг метки( А -Р) по горизонтали
        public int HSpacing
        {
            get { return hspacing; }
            set
            {
                hspacing = value;
            }
        }

        private int vspacing1 = 30; // сдвиг метки( А -Р) по вертикали
        public int VSpacing1
        {
            get { return vspacing1; }
            set
            {
                vspacing1 = value;
            }
        }





        private int hspacing1 = -14; // сдвиг метки( А -Р) по горизонтали
        public int HSpacing1
        {
            get { return hspacing1; }
            set
            {
                hspacing1 = value;
            }
        }

        private int vspacing = -5; // сдвиг метки( А -Р) по вертикали
        public int VSpacing
        {
            get { return vspacing; }
            set
            {
                vspacing = value;
            }
        }

        private string checkedLabel = "ОТКР";
        public string CheckedLabel
        {
            get { return checkedLabel; }
            set
            {
                checkedLabel = value;
            }
        }

        private string uncheckedLabel = "ЗАКР";
        public string UncheckedLabel
        {
            get { return uncheckedLabel; }
            set
            {
                uncheckedLabel = value;
            }
        }

        private bool showAutoLabel = false;
        public bool ShowAutoLabel
        {
            get { return showAutoLabel; }
            set
            {
                showAutoLabel = value;
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            if (this.AssociatedObject != null)
            {

                this.AssociatedObject.Cursor = Cursors.Hand;

                


                handleControlBehavior = new OptionsBehavior();
                handleControlBehavior.FeedbackOnPressed = true;
                this.AssociatedObject.OptionsBehavior = handleControlBehavior;



                // для ручного режима
                var position = AssociatedObject.Height;


                open = new Arrow();
                open.RotateAngle = 270;

                open.Colors = new ControlColors();
                //open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Green };
                open.Width = 20;
                open.Height = 20;

                close = new Arrow();
                close.RotateAngle = 90;

                close.Colors = new ControlColors();
                //open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Green };
                close.Width = 20;
                close.Height = 20;



                var left = Canvas.GetLeft(AssociatedObject);
                Canvas.SetLeft(open, left + HSpacing);
                var top = Canvas.GetTop(AssociatedObject);
                Canvas.SetTop(open, top + VSpacing);

                var left1 = Canvas.GetLeft(AssociatedObject);
                Canvas.SetLeft(close, left1 + HSpacing1);
                var top1 = Canvas.GetTop(AssociatedObject);
                Canvas.SetTop(close, top1 + VSpacing1);

              

                var canvas = (Canvas)(AssociatedObject.Parent);

             
                canvas.Children.Add(open);
                canvas.Children.Add(close);


                //var idx1 = Canvas.GetZIndex(AssociatedObject);
                //Canvas.SetZIndex(AssociatedObject, 1);
                //Canvas.SetZIndex(openBorder, 0);


                // this.AssociatedObject.Click += onClick;

                Update();
            }


        }



        private void onClick(object sender, RoutedEventArgs e)
        {
            popupPanel.IsOpen = !popupPanel.IsOpen;
            //Out = true;
        }

        protected override void OnDetaching()
        {

           // this.AssociatedObject.Click -= onClick;

            base.OnDetaching();
        }


        private void Update()
        {
            if (AssociatedObject != null)
            {
                if (isOpenValve)
                {

                    open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Green };
                    

                }
                else
                {
                
                    open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Black };
                }    
                



                 if (isCloseValve)
                {


                    open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Red };
                   


                }
                else
                {

                    open.Colors.DefaultColoring = new ColoringColor() { Color1 = System.Windows.Media.Colors.Black };

                }
                   

              
            }
        }

    }

}
