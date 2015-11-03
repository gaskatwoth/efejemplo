using wpf.MiBd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //enviar boton y metodo
             if (Regex.IsMatch(sueldo.Text, @"^\d+$")&& Regex.IsMatch(nombre.Text,@"^[a-zA-Z]+$"))
            {
            demoEf db = new demoEf();
            Empleado emp = new Empleado();
            emp.nombre = nombre.Text;
            emp.sueldo = int.Parse(sueldo.Text);

            db.Empleados.Add(emp);
            db.SaveChanges();
        }
             else {MessageBox.Show("Solo letras y numero");}
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //actualizar boton y metodo
            if ( Regex.IsMatch(sueldo.Text, @"^\d+$") && Regex.IsMatch(nombre.Text, @"^[a-zA-Z]+$"))
            {
                demoEf db = new demoEf();
                int id = int.Parse(Actualizar.Text);
                var emp = db.Empleados.SingleOrDefault(x => x.id == id);
                //from x in db.Empleados
                //          where x.id==id
                //          select x;
                if (emp != null)
                {
                    emp.nombre = nombre.Text;
                    emp.sueldo = int.Parse(sueldo.Text);
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo letras y numeros"); }

        }

        private void borrar_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(Actualizar.Text, @"^\d+$"))
            {
                demoEf db = new demoEf();
                int id = int.Parse(Actualizar.Text);
                var emp = db.Empleados.SingleOrDefault(x => x.id == id);
                //from x in db.Empleados
                //          where x.id==id
                //          select x;
                if (emp != null)
                {
                    db.Empleados.Remove(emp);
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros en #id "); }
        }


        private void Consultar_Click(object sender, RoutedEventArgs e)
        {
            if(Regex.IsMatch(Actualizar.Text, @"^\d+$")){
            demoEf db = new demoEf();
            int id = int.Parse(Actualizar.Text);
            var registros = from s in db.Empleados
                            where s.id == id
                            select new
                            {
                                s.nombre,
                                s.sueldo
                            };
            dbgrid.ItemsSource = registros.ToList();
            }
            else { MessageBox.Show("Solo numeros"); }
        }


        private void dbgrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ConsultarTodo_Click(object sender, RoutedEventArgs e)
        {
            demoEf db = new demoEf();
            //int id = int.Parse(Actualizar.Text);
            var registros = from s in db.Empleados
                            //where s.id == id
                            select s;
                         
            dbgrid.ItemsSource = registros.ToList();
        }

        private void Actualizar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
