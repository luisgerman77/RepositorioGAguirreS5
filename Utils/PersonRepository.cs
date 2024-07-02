using GAguirreS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace GAguirreS5.Utils
{
    public class PersonRepository
    {
        private readonly string _dbPath; 
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        //Todo:Add variable for the SQLite connection

        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Persona>();

        }
        public PersonRepository (string dbPath) 
        { 
         _dbPath = dbPath;
        }

        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("nombre requerido");

                Persona persona = new() { Nombre = nombre };
                result = conn.Insert(persona);
                StatusMessage = $"Datos añadidos correctamente: {result} - {nombre}";
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error añadiendo {nombre}: {ex.Message}";
            }
        }

        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al mostrar:{0}", ex.Message);
            
            return new List<Persona>();
        }
   }
         public void UpdatePerson (int id,string nombre)
        {
            try
            {
                Init();
                 var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person == null)
                    throw new Exception("Persona no encontrada");
            
                 person.Nombre = nombre;
                conn.Update(person);
                StatusMessage = $"Persona actualizada correctamente: {id} - {nombre}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error actualizando {nombre}: {ex.Message}";

            }
        }

public void DeletePerson(int id)
{
    try
    {
        Init();
        var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
        if (person == null)
            throw new Exception("Persona no encontrada");

        conn.Delete(person);
        StatusMessage = $"Persona eliminada correctamente: {id}";
    }
    catch (Exception ex)
    {
        StatusMessage = $"Error eliminando persona con ID {id}: {ex.Message}";

    }
   }
  }
}
