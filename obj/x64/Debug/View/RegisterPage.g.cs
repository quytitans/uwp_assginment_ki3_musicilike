﻿#pragma checksum "D:\06. Universal App\MainStudyApp\View\RegisterPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DB02519579A2A1427B0C7E4B9E68564FF500F6B73B95FE60FBAAB03095802B69"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainStudyApp.View
{
    partial class RegisterPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\RegisterPage.xaml line 40
                {
                    this.firstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // View\RegisterPage.xaml line 41
                {
                    this.msgFirstName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // View\RegisterPage.xaml line 42
                {
                    this.lastName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // View\RegisterPage.xaml line 43
                {
                    this.msgLastName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // View\RegisterPage.xaml line 44
                {
                    this.password = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 7: // View\RegisterPage.xaml line 45
                {
                    this.msgPassword = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // View\RegisterPage.xaml line 46
                {
                    this.confirmPassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 9: // View\RegisterPage.xaml line 47
                {
                    this.msgConfirmPassword = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // View\RegisterPage.xaml line 48
                {
                    this.address = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 11: // View\RegisterPage.xaml line 49
                {
                    this.msgAddress = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // View\RegisterPage.xaml line 50
                {
                    this.phone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13: // View\RegisterPage.xaml line 51
                {
                    this.msgPhone = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // View\RegisterPage.xaml line 52
                {
                    this.avatar = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15: // View\RegisterPage.xaml line 53
                {
                    this.msgAvatar = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 16: // View\RegisterPage.xaml line 58
                {
                    this.msgGender = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // View\RegisterPage.xaml line 59
                {
                    this.email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 18: // View\RegisterPage.xaml line 60
                {
                    this.msgEmail = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 19: // View\RegisterPage.xaml line 61
                {
                    this.birthDayPicker = (global::Windows.UI.Xaml.Controls.CalendarDatePicker)(target);
                    ((global::Windows.UI.Xaml.Controls.CalendarDatePicker)this.birthDayPicker).DateChanged += this.CalendarDatePicker_DateChanged;
                }
                break;
            case 20: // View\RegisterPage.xaml line 62
                {
                    this.msgBirthDay = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 21: // View\RegisterPage.xaml line 63
                {
                    this.introduction = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 22: // View\RegisterPage.xaml line 65
                {
                    global::Windows.UI.Xaml.Controls.Button element22 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element22).Click += this.SubmitBtnCLick;
                }
                break;
            case 23: // View\RegisterPage.xaml line 66
                {
                    global::Windows.UI.Xaml.Controls.Button element23 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element23).Click += this.Reset_Click;
                }
                break;
            case 24: // View\RegisterPage.xaml line 55
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element24 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element24).Tapped += this.RadioButton_Tapped;
                }
                break;
            case 25: // View\RegisterPage.xaml line 56
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element25 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element25).Tapped += this.RadioButton_Tapped;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
