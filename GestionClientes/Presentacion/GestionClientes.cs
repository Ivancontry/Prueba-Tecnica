using Entidad;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class GestionClientes : Form
    {
        
        ServicioClientes ServiciosCliente = new ServicioClientes();
        Validaciones Validaciones = new Validaciones();
        Cliente Cliente = new Cliente();
        List<Cliente> Clientes = new List<Cliente>();
        public GestionClientes()
        {
            InitializeComponent();
            InhabilitarCampos();
            ConsultarClientes();
        }

        private void InhabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtSalario.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void LimpiarInformacionDelCliente() {
            txtIdentificacion.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtSalario.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            labelEstado.Text = "";
            labelFechaRegistro.Text = "";
        }
        private void HabilitarCampos()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtSalario.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
        }

        private void HabilitarBotonGuardar() {
            btnGuardar.Enabled = true; ;
        }
        private void HabilitarBotonEliminar()
        {
            btnEliminar.Enabled = true; ;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cliente == null)
            {
                var errores = ValidarCliente();
                if (errores.Count > 0)
                {
                    MessageBox.Show(MapearErrores(errores), "Campos Invalidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var cliente = new Cliente(txtIdentificacion.Text, txtNombre.Text, txtApellido.Text,
                                              txtTelefono.Text, txtDireccion.Text, double.Parse(txtSalario.Text));
                    MessageBox.Show(ServiciosCliente.Registrar(cliente), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarInformacionDelCliente();
                    this.InhabilitarCampos();                    
                    Cliente = ServiciosCliente.BuscarPorIdentificacion(cliente.Identificacion);
                    ConsultarClientes();

                }
            }
            else {
                var errores = ValidarCliente();
                if (errores.Count > 0)
                {
                    MessageBox.Show(MapearErrores(errores), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cliente.Editar(txtIdentificacion.Text, txtNombre.Text, txtApellido.Text,
                                              txtTelefono.Text, txtDireccion.Text, double.Parse(txtSalario.Text));
                    MessageBox.Show(ServiciosCliente.Actualizar(Cliente));
                    this.LimpiarInformacionDelCliente();
                    this.InhabilitarCampos();
                    ConsultarClientes();
                }
            }
        }

        private string MapearErrores(List<string> errores) {
            var mensaje = "";
            errores.ForEach(t=> {
                mensaje += "- " + t + "\n";
            });
            return mensaje;
        }

        private void ConsultarClientes()
        {
            Clientes = ServiciosCliente.ConsultarClientes();
            if (Clientes == null) return;
            LlenarDataGridView(Clientes);
        }

        private void LlenarDataGridView(IEnumerable<Cliente> clientes)
        {
            if (clientes == null) return;
            LimpiarDatagridView(tableClientes);
            foreach (Cliente cliente in clientes)
            {
                tableClientes.Rows.Add(cliente.FechaCreacion.ToShortDateString(),
                                        cliente.Identificacion,
                                        cliente.Nombres,
                                        cliente.Apellidos,
                                        cliente.Telefono,
                                        cliente.Direccion,
                                        cliente.Salario,
                                        cliente.Estado);
            }
        }

        private void LimpiarDatagridView(DataGridView dataGridView)
        {
            if (dataGridView?.CurrentRow == null) return;
            while (dataGridView.RowCount >= 1)
            {
                dataGridView.Rows.Remove(dataGridView.CurrentRow);
            }
        }

        private List<string> ValidarCliente() {
            var errores = new List<string>();
            if (Validaciones.ValidarIdentificacion(txtIdentificacion.Text) && Validaciones.ValidarTexto(txtIdentificacion.Text)) {
                errores.Add("Identificación Invalida");
            }
            if (Validaciones.ValidarNombres(txtNombre.Text) && Validaciones.ValidarTexto(txtNombre.Text))
            {
                errores.Add("Nombres Invalidos");
            }
            if (Validaciones.ValidarApellidos(txtApellido.Text) && Validaciones.ValidarTexto(txtApellido.Text))
            {
                errores.Add("Apellidos Invalidos");
            }
            return errores;
        }

        private string Buscar(string identificacion) {
            try
            {
                if (Validaciones.ValidarIdentificacion(identificacion) && Validaciones.ValidarSoloNumeros(identificacion)) {
                     Cliente = ServiciosCliente.BuscarPorIdentificacion(identificacion);
                    if (Cliente != null)
                    {
                        MapearClienteEnFormulario();
                        HabilitarCampos();
                        HabilitarBotonEliminar();
                        HabilitarBotonGuardar();
                        return "¡Cliente encontrado con Exito!";
                    }
                    else {
                        HabilitarCampos();
                        HabilitarBotonGuardar();
                        return "¡Cliente no encontrado!";
                    }

                }
                else
                    return "Lo sentimos. Ha ocurrido un error. Ingrese datos validos";

            }
            catch (Exception)
            {
                return "Lo sentimos. Ha ocurrido un error.";
            }
        
        }

        private void MapearClienteEnFormulario()
        {
            txtNombre.Text = Cliente.Nombres;
            txtApellido.Text = Cliente.Apellidos;
            txtSalario.Text = Cliente.Salario.ToString();
            txtTelefono.Text = Cliente.Telefono;
            txtDireccion.Text = Cliente.Direccion;
            labelFechaRegistro.Text = Cliente.FechaCreacion.ToShortDateString();
            labelEstado.Text = Cliente.Estado.ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Buscar(txtIdentificacion.Text),"", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {            
            MessageBox.Show(CambiarEstadoDeUnCliente(Cliente.Id, EstadoGeneral.Inactivo), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string CambiarEstadoDeUnCliente(int id, EstadoGeneral estado) 
        {
            var mensaje =  ServiciosCliente.CambiarEstado(id,estado);
            Cliente = ServiciosCliente.BuscarPorIdentificacion(Cliente.Identificacion);
            LimpiarInformacionDelCliente();
            InhabilitarCampos();
            ConsultarClientes();
            return mensaje;
        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
