# Actual Filter Test Doku
### MainWindow.xaml.cs

```csharp
using System;
using System.Windows;
using System.Xml.Linq;

namespace actual_filter_test
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Load XML data
            XDocument xdoc = XDocument.Load("data.xml");

            // Filter XML data
            var filteredData = FilterXmlData(xdoc);

            // Display filtered data
            MessageBox.Show(filteredData.ToString());
        }

        private XElement FilterXmlData(XDocument xdoc)
        {
            // Implement the filtering logic here
            XElement root = new XElement("FilteredData");

            foreach (var element in xdoc.Descendants("YourElementName"))
            {
                if (element.Attribute("YourAttributeName")?.Value == "YourAttributeValue")
                {
                    root.Add(element);
                }
            }

            return root;
        }
    }
}
```

#### Erklärung der `MainWindow.xaml.cs` Datei:

1. **Imports und Namensräume**: Die Datei beginnt mit den `using`-Anweisungen, die notwendige Namespaces importieren, insbesondere für die Arbeit mit XML-Daten und WPF-Elementen.
   
2. **MainWindow Klasse**: Diese Klasse repräsentiert das Hauptfenster der Anwendung.
   
3. **Konstruktor `MainWindow`**: Der Konstruktor initialisiert das Hauptfenster und ruft die `InitializeComponent` Methode auf, um die im XAML definierten UI-Elemente zu initialisieren.

4. **Button_Click Methode**: 
    - Diese Methode wird ausgeführt, wenn ein Button im UI angeklickt wird.
    - Die Methode lädt eine XML-Datei (`data.xml`), filtert die Daten durch Aufruf der `FilterXmlData` Methode und zeigt die gefilterten Daten in einer MessageBox an.

5. **FilterXmlData Methode**:
    - Diese Methode übernimmt die eigentliche Filterlogik.
    - Ein neues XML-Element `root` wird erstellt, um die gefilterten Daten zu speichern.
    - Die Methode iteriert über die XML-Elemente mit dem Namen `YourElementName` und überprüft, ob das Attribut `YourAttributeName` den Wert `YourAttributeValue` hat.
    - Wenn die Bedingung erfüllt ist, wird das Element zum `root` hinzugefügt.

### MainWindow.xaml

```xml
<Window x:Class="actual_filter_test.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <Button Content="Filter XML" HorizontalAlignment="Left" VerticalAlignment="Top" Width="75" Click="Button_Click"/>
    </Grid>
</Window>
```

#### Erklärung der `MainWindow.xaml` Datei:

1. **Window Definition**: Definiert das Hauptfenster mit einer festen Höhe und Breite.
2. **Grid Layout**: Ein einfaches Grid-Layout wird verwendet, um die UI-Elemente zu platzieren.
3. **Button**: Ein Button wird definiert, der bei einem Klick die `Button_Click` Methode ausführt.

### Weitere Dateien

- **`actual_filter_test.csproj`**: Diese Projektdatei definiert die Konfiguration und Abhängigkeiten des Projekts. 
- **`App.xaml` und `App.xaml.cs`**: Diese Dateien definieren die Anwendungsressourcen und das Startverhalten.
- **`AssemblyInfo.cs`**: Enthält Metadaten über die Assembly, wie Versionsinformationen und andere Attribute.

### Dokumentationserweiterung

#### Implementierte Komponenten

1. **Projektdatei (actual_filter_test.csproj)**:
   - Definiert die Projektkonfiguration und Abhängigkeiten, einschließlich notwendiger Bibliotheken für die Arbeit mit WPF und XML.

2. **MainWindow.xaml & MainWindow.xaml.cs**:
   - **MainWindow.xaml**: Enthält das Layout und die UI-Elemente des Hauptfensters. Hier wird ein Button definiert, der bei einem Klick die Filterlogik ausführt.
   - **MainWindow.xaml.cs**: Enthält die Logik für die Benutzerinteraktionen und die XML-Filterung. Die `Button_Click` Methode lädt eine XML-Datei, filtert die Daten basierend auf bestimmten Bedingungen und zeigt die gefilterten Daten an.

3. **AssemblyInfo.cs**:
   - Enthält Metadaten zur Assembly, wie Versionsinformationen und andere Attribute.
