using System;
using System.Collections; 
namespace HashTables
{
	public class claseProgra
	{
		
		private Hashtable tabla;
		
		public claseProgra (){
			this.tabla = new Hashtable();
		}
		
		private void capturaDeDatos (Datos datos){
			Console.WriteLine ("\nIntroducir los datos\n");
			
			if(datos.ID == "" ){  
				Console.WriteLine ("Introducir codigo de registro");
				datos.ID = Console.ReadLine ();  }
			
			Console.WriteLine ("Nombre: ");
			datos.nombre = Console.ReadLine (); 
			
			Console.WriteLine ("Direccion: ");
			datos.direccion = Console.ReadLine (); 
			
			Console.WriteLine ("Email: ");
			datos.e_mail = Console.ReadLine (); 
			
			Console.WriteLine ("Telefono: ");
			datos.telefono = Console.ReadLine ();        	
		}
		
		private void capturarPersona(Datos datos ){
			this.capturaDeDatos (datos); 
			
			this.agregaPersona(datos);
		}
		
		public void captura(){         
			for(int i=0; i<4; i++){
				Console.Clear();
				this.capturarPersona(new Datos()); 
			}
		}
		
		private void agregaPersona(Datos datos){
			
			if( this.tabla.ContainsKey(datos.ID)){
				this.tabla.Remove(datos.ID);
			}
			
			this.tabla.Add(datos.ID,datos);	
		}
		private void printPerson(Datos datos){
			
			Console.WriteLine ("Clave\n"+datos.ID);
			Console.WriteLine ("Nobre\n"+datos.nombre);
			Console.WriteLine ("Direccion\n"+datos.direccion);
			Console.WriteLine ("Telefono\n"+datos.telefono);
			Console.WriteLine ("Email\n"+datos.e_mail);
			
		}
		
		private void printFail(){
			Console.WriteLine ("clave no existente ");
			Console.WriteLine ("Presionar tecla para continuar ");
			Console.ReadLine (); 
			
		}
		
		public void edit(){
			
			for(int i=0; i<2; i++){
				Console.Clear(); 
				string ID = "";
				Console.WriteLine("Ingresar codigo");
				ID = Console.ReadLine(); 
				if(this.tabla.ContainsKey(ID)){
					
					Datos datos = (Datos)this.tabla[ID]; 
					this.printPerson(datos);
					this.capturarPersona(datos);
				}else{this.printFail();    
					
				}
			}
		}
		
		private void confirmDelete(string ID){
			
			Console.WriteLine ("El registro sera eliminado");
			Console.WriteLine (" 0 Cancelar 1 Aceptar ");
			string opcion = Console.ReadLine (); 
			if(opcion !="0"){  
				this.tabla.Remove(ID);
			}
		}
		
		public void delete(){
			for(int i=0; i<2; i++){
				Console.Clear(); 
				string ID = ""; 
				Console.WriteLine("Ingrese codigo");
				ID= Console.ReadLine(); 
				
				if(this.tabla.ContainsKey(ID)){ 
					Datos datos = (Datos)this.tabla[ID]; 
					this.printPerson(datos);
					this.confirmDelete(datos.ID);
					
				}else{ 
					this.printFail(); 
					
				}
			}	
		}
		public void printAll(){
			
			ICollection registros = this.tabla.Values; 
			foreach(object objeto in registros){
				
				Datos datos = (Datos) objeto; 
				this.printPerson(datos);
			}
		}
	}
}