using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using T12.DTO;
using T12.DAL;

namespace T12.BL
{
    public class DeviceManager
    {
        DeviceDAL deviceDAL;

        public DeviceManager()
        {
            deviceDAL = new DeviceDAL();
        }
        public List<Device> Find(string key)
        {
            // 1. key - quantity
            // 2. key - name
            int id;
            bool success = int.TryParse(key, out id);
            if (success)
            {
                return deviceDAL.SelectByIdOrQuantity(id);
            }
            else
            {
                return deviceDAL.SelectByName(key);
            }
        }
        public void Import(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            try
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //tách chuỗi gán vào mảng 
                    string[] tokens = line.Split(',');
                    string name = tokens[0];
                    int quantity = Convert.ToInt32(tokens[1]);
                    deviceDAL.Insert(new Device(0, name, quantity));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Close();
            }
        }

        public void Export(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
            try
            {
                foreach (Device item in deviceDAL.SelectAll())
                {
                    writer.WriteLine(item);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                writer.Close();
            }
        }

        public int AddNew(Device d)
        {
            return deviceDAL.Insert(d);
        }

        public int UpdateName(Device d)
        {
            return deviceDAL.UpdateName(d);
        }

        public int UpdateQuantity(Device d)
        {
            return deviceDAL.UpdateQuantity(d);
        }

        public int Delete(Device d)
        {
            return deviceDAL.Delete(d.Id);
        }
    }
}
