using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Windows;

namespace XmlExtractor
{
    public partial class MainWindow : Window
    {
        private XDocument loadedDocument;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadXml_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                loadedDocument = XDocument.Load(openFileDialog.FileName);
                txtXmlOutput.Text = "XML loaded successfully!";
            }
        }

        private void btnExtractAndSave_Click(object sender, RoutedEventArgs e)
        {
            if (loadedDocument == null)
            {
                txtXmlOutput.Text = "Please load an XML document first.";
                return;
            }

            XDocument resultDocument = new XDocument(new XElement("database"));

            foreach (var vmd in new[] { "VMD_03", "VMD_04" })
            {
                var vmdElements = loadedDocument.Root.Elements(vmd);
                foreach (var vmdElement in vmdElements)
                {
                    XElement newVmdElement = new XElement(vmd);
                    resultDocument.Root.Add(newVmdElement);

                    foreach (var vt in new[] { "VT_1", "VT_2" })
                    {
                        var vtElements = vmdElement.Elements(vt);
                        foreach (var vtElement in vtElements)
                        {
                            XElement newVtElement = new XElement(vt);
                            newVmdElement.Add(newVtElement);

                            foreach (var meaName in new[] { "MEA20_1", "MEA20_2", "MEA20_3", "MEA20_33", "MEA20_34", "MEA20_35" })
                            {
                                var meaElements = vtElement.Elements("MEA").Where(mea => mea.Attribute("name")?.Value == meaName);
                                foreach (var meaElement in meaElements)
                                {
                                    newVtElement.Add(new XElement(meaElement));
                                }
                            }
                        }
                    }
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                resultDocument.Save(saveFileDialog.FileName);
                txtXmlOutput.Text = "Filtered XML saved successfully!";
            }
        }
    }
}