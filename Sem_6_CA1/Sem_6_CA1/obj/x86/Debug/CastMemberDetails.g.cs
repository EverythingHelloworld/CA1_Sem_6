﻿#pragma checksum "C:\Users\Maria\source\repos\CA1_Sem_6\Sem_6_CA1\Sem_6_CA1\CastMemberDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E66801DD0CFACC919E8E8C267624E083"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sem_6_CA1
{
    partial class CastMemberDetails : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // CastMemberDetails.xaml line 11
                {
                    this.OuterGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // CastMemberDetails.xaml line 20
                {
                    this.OptionsMenu = (global::Windows.UI.Xaml.Controls.NavigationView)(target);
                    ((global::Windows.UI.Xaml.Controls.NavigationView)this.OptionsMenu).BackRequested += this.On_BackRequested;
                    ((global::Windows.UI.Xaml.Controls.NavigationView)this.OptionsMenu).ItemInvoked += this.NavView_ItemInvoked;
                }
                break;
            case 4: // CastMemberDetails.xaml line 27
                {
                    this.CastMemberDetailsGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5: // CastMemberDetails.xaml line 36
                {
                    this.CastMemberInfoGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // CastMemberDetails.xaml line 61
                {
                    this.CastMemberRoleGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 7: // CastMemberDetails.xaml line 73
                {
                    this.CastMemberRole = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // CastMemberDetails.xaml line 74
                {
                    this.CastMemActiveFrom = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9: // CastMemberDetails.xaml line 83
                {
                    this.NotableSceneVid = (global::Windows.UI.Xaml.Controls.MediaPlayerElement)(target);
                }
                break;
            case 10: // CastMemberDetails.xaml line 81
                {
                    this.NotableVidDesc = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // CastMemberDetails.xaml line 77
                {
                    this.CastMemRoleBio = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12: // CastMemberDetails.xaml line 47
                {
                    this.castMemberImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 13: // CastMemberDetails.xaml line 48
                {
                    this.CastMemberName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14: // CastMemberDetails.xaml line 49
                {
                    this.CastMemberDOB = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // CastMemberDetails.xaml line 50
                {
                    this.IMDBButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.IMDBButton).Click += this.IMDBButton_Click;
                }
                break;
            case 16: // CastMemberDetails.xaml line 59
                {
                    this.stars = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 17: // CastMemberDetails.xaml line 56
                {
                    this.CastMemberBio = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // CastMemberDetails.xaml line 51
                {
                    this.IMDBLink = (global::Windows.UI.Xaml.Controls.Image)(target);
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

