//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XamlStaticHelperNamespace {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XamlBuildTask", "4.0.0.0")]
    internal class _XamlStaticHelper {
        
        private static System.WeakReference schemaContextField;
        
        private static System.Collections.Generic.IList<System.Reflection.Assembly> assemblyListField;
        
        internal static System.Xaml.XamlSchemaContext SchemaContext {
            get {
                System.Xaml.XamlSchemaContext xsc = null;
                if ((schemaContextField != null)) {
                    xsc = ((System.Xaml.XamlSchemaContext)(schemaContextField.Target));
                    if ((xsc != null)) {
                        return xsc;
                    }
                }
                if ((AssemblyList.Count > 0)) {
                    xsc = new System.Xaml.XamlSchemaContext(AssemblyList);
                }
                else {
                    xsc = new System.Xaml.XamlSchemaContext();
                }
                schemaContextField = new System.WeakReference(xsc);
                return xsc;
            }
        }
        
        internal static System.Collections.Generic.IList<System.Reflection.Assembly> AssemblyList {
            get {
                if ((assemblyListField == null)) {
                    assemblyListField = LoadAssemblies();
                }
                return assemblyListField;
            }
        }
        
        private static System.Collections.Generic.IList<System.Reflection.Assembly> LoadAssemblies() {
            System.Collections.Generic.IList<System.Reflection.Assembly> assemblyList = new System.Collections.Generic.List<System.Reflection.Assembly>();
            assemblyList.Add(Load("Microsoft.CSharp, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a" +
                        "3a"));
            assemblyList.Add(Load("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e" +
                        "35"));
            assemblyList.Add(Load("PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856a" +
                        "d364e35"));
            assemblyList.Add(Load("ReachFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" +
                        ""));
            assemblyList.Add(Load("System.ComponentModel.DataAnnotations, Version=4.0.0.0, Culture=neutral, PublicKe" +
                        "yToken=31bf3856ad364e35"));
            assemblyList.Add(Load("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Data.DataSetExtensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b" +
                        "77a5c561934e089"));
            assemblyList.Add(Load("System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" +
                        ""));
            assemblyList.Add(Load("System.Net.Http, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" +
                        "a"));
            assemblyList.Add(Load("System.Printing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e3" +
                        "5"));
            assemblyList.Add(Load("System.Runtime.Serialization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b7" +
                        "7a5c561934e089"));
            assemblyList.Add(Load("System.ServiceProcess, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f1" +
                        "1d50a3a"));
            assemblyList.Add(Load("System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856a" +
                        "d364e35"));
            assemblyList.Add(Load("System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c5619" +
                        "34e089"));
            assemblyList.Add(Load("System.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"));
            assemblyList.Add(Load("System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e08" +
                        "9"));
            assemblyList.Add(Load("UIAutomationProvider, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad" +
                        "364e35"));
            assemblyList.Add(Load("UIAutomationTypes, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364" +
                        "e35"));
            assemblyList.Add(Load("WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"));
            assemblyList.Add(Load("WindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf385" +
                        "6ad364e35"));
            assemblyList.Add(Load("MRNNexus.DTOs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"));
            assemblyList.Add(Load("Newtonsoft.Json, Version=8.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aee" +
                        "d"));
            assemblyList.Add(Load("Syncfusion.Data.WPF, Version=14.1460.0.41, Culture=neutral, PublicKeyToken=3d67ed" +
                        "1f87d44c89"));
            assemblyList.Add(Load("Syncfusion.SfBusyIndicator.WPF, Version=14.1460.0.41, Culture=neutral, PublicKeyT" +
                        "oken=3d67ed1f87d44c89"));
            assemblyList.Add(Load("Syncfusion.SfGrid.WPF, Version=14.1460.0.41, Culture=neutral, PublicKeyToken=3d67" +
                        "ed1f87d44c89"));
            assemblyList.Add(Load("Syncfusion.SfInput.Wpf, Version=14.1460.0.41, Culture=neutral, PublicKeyToken=3d6" +
                        "7ed1f87d44c89"));
            assemblyList.Add(Load("Syncfusion.SfRadialMenu.Wpf, Version=14.1460.0.41, Culture=neutral, PublicKeyToke" +
                        "n=3d67ed1f87d44c89"));
            assemblyList.Add(Load("Syncfusion.SfSchedule.WPF, Version=14.1460.0.41, Culture=neutral, PublicKeyToken=" +
                        "3d67ed1f87d44c89"));
            assemblyList.Add(Load("Syncfusion.SfShared.Wpf, Version=14.1460.0.41, Culture=neutral, PublicKeyToken=3d" +
                        "67ed1f87d44c89"));
            assemblyList.Add(Load("Syncfusion.Shared.Wpf, Version=14.1460.0.41, Culture=neutral, PublicKeyToken=3d67" +
                        "ed1f87d44c89"));
            assemblyList.Add(Load("Syncfusion.Tools.Wpf, Version=14.1460.0.41, Culture=neutral, PublicKeyToken=3d67e" +
                        "d1f87d44c89"));
            assemblyList.Add(Load("System.Net.Http.Formatting, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf" +
                        "3856ad364e35"));
            assemblyList.Add(Load("System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31" +
                        "bf3856ad364e35"));
            assemblyList.Add(Load("ToggleSwitch, Version=1.1.2.0, Culture=neutral, PublicKeyToken=8637099990568f75"));
            assemblyList.Add(System.Reflection.Assembly.GetExecutingAssembly());
            return assemblyList;
        }
        
        private static System.Reflection.Assembly Load(string assemblyNameVal) {
            System.Reflection.AssemblyName assemblyName = new System.Reflection.AssemblyName(assemblyNameVal);
            byte[] publicKeyToken = assemblyName.GetPublicKeyToken();
            System.Reflection.Assembly asm = null;
            try {
                asm = System.Reflection.Assembly.Load(assemblyName.FullName);
            }
            catch (System.Exception ) {
                System.Reflection.AssemblyName shortName = new System.Reflection.AssemblyName(assemblyName.Name);
                if ((publicKeyToken != null)) {
                    shortName.SetPublicKeyToken(publicKeyToken);
                }
                asm = System.Reflection.Assembly.Load(shortName);
            }
            return asm;
        }
    }
}
