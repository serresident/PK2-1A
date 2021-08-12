﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace belofor.Controls
{
    [TemplatePart(Name = "PART_Caption", Type = typeof(TextBlock))]
    public class ValueBlock : Control
    {
        public string Caption
        {
            get { return (string)this.GetValue(CaptionProperty); }
            set { this.SetValue(CaptionProperty, value); }
        }
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register(
          "Caption", typeof(string), typeof(ValueBlock), new PropertyMetadata(string.Empty));


        public string Value
        {
            get { return (string)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
          "Value", typeof(string), typeof(ValueBlock), new UIPropertyMetadata("0.0", onValueChanged));

        private static void onValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue.ToString() != "???")
                if(e.NewValue.ToString() !="NaN")
                if (float.Parse(e.NewValue.ToString()) < float.Parse("-100")) (d as ValueBlock).Value = "???";
        }

        public string Unit
        {
            get { return (string)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }
        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
          "Unit", typeof(string), typeof(ValueBlock), new PropertyMetadata(string.Empty));

        public Brush ValueColor
        {
            get { return (System.Windows.Media.Brush)this.GetValue(ValueColorProperty); }
            set { this.SetValue(ValueColorProperty, value); }
        }
        public static readonly DependencyProperty ValueColorProperty = DependencyProperty.Register(
            "ValueColor", typeof(Brush), typeof(ValueBlock), new PropertyMetadata(new SolidColorBrush(Colors.Green)));

        static ValueBlock()
        {
            ForegroundProperty.OverrideMetadata(typeof(ValueBlock), new FrameworkPropertyMetadata(Brushes.Gray, OnForegroundChanged));
            WidthProperty.OverrideMetadata(typeof(ValueBlock), new FrameworkPropertyMetadata((double)100));
            HeightProperty.OverrideMetadata(typeof(ValueBlock), new FrameworkPropertyMetadata((double)50));

            DefaultStyleKeyProperty.OverrideMetadata(typeof(ValueBlock), new FrameworkPropertyMetadata(typeof(ValueBlock)));
        }

        private static void OnForegroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            MethodInfo mi = typeof(DependencyPropertyChangedEventArgs).GetMethod("get_OperationType",
                                                                                  BindingFlags.NonPublic |
                                                                                  BindingFlags.Instance);
            var v = mi.Invoke(e, null);

            if ((e.NewValue != Brushes.Gray) && (v.ToString() == "AddChild"))
            {
                ((ValueBlock)d).Foreground = Brushes.Gray;
            }
            else
            {
                ((ValueBlock)d).Foreground = (SolidColorBrush)(e.NewValue);
            }
        }
    }



}
