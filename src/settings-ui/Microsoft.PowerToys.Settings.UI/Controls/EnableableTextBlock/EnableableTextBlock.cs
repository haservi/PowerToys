﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Microsoft.PowerToys.Settings.UI.Controls
{
    [TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
    [TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
    public class EnableableTextBlock : Control
    {
        public EnableableTextBlock()
        {
            this.DefaultStyleKey = typeof(EnableableTextBlock);
        }

        protected override void OnApplyTemplate()
        {
            IsEnabledChanged -= EnableableTextBlock_IsEnabledChanged;
            SetEnabledState();
            IsEnabledChanged += EnableableTextBlock_IsEnabledChanged;
            base.OnApplyTemplate();
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
           "Text",
           typeof(string),
           typeof(EnableableTextBlock),
           null);

        [Localizable(true)]
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private void EnableableTextBlock_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetEnabledState();
        }

        private void SetEnabledState()
        {
            VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled", true);
        }
    }
}