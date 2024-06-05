using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4.Extentions;

namespace WpfApp4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnGenerate_OnClick(object sender, RoutedEventArgs e)
    {
        PasswordGenerator generator = new PasswordGenerator();

        switch (CbDiff.SelectedIndex)
        {
            case 0:
                TbBox.Text = generator.GeneratePassword(DifPass.Easy, Convert.ToInt32(TbLeinght.Text));
                break;
            case 1:
                TbBox.Text = generator.GeneratePassword(DifPass.Medium, Convert.ToInt32(TbLeinght.Text));
                break;
            case 2:
                TbBox.Text = generator.GeneratePassword(DifPass.Hard, Convert.ToInt32(TbLeinght.Text));
                break;
        }


    }

    private void TbLeinght_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        if ((e.Key < Key.D0 || e.Key > Key.D9) && e.Key != Key.Back)
        {
            e.Handled = true;
        }
    }
}
