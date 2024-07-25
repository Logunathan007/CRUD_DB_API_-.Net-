using CRUD_DB_Using_API.Model.Entitys;

namespace CRUD_DB_Using_API.Model.Operations
{
    public class DML
    {
        MakeConnection conn;
        public DML() 
        {
            conn = new MakeConnection();
        }

        public List<Employee> GetAllData()
        {
            return this.conn.Employees.ToList();
        }
        public Employee GetDataById(int id)
        {
            return this.conn.Employees.ToList().Find(e=>e.Id == id);
        }
        public Boolean InsertData(Employee obj)
        {
            
            if (null == GetAllData().Find(e => e.Id == obj.Id))
            {
                this.conn.Employees.Add(obj);
                this.conn.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }
        public Boolean DeleteData(int id)
        {
            var obj = GetAllData().Find(e => e.Id == id);
            if (null != obj)
            {
                this.conn.Employees.Remove(obj);
                this.conn.SaveChanges();
                return true;
            }else
                { return false; }
        }
        public Boolean UpdateData(int id,Employee obj)
        {
            var temp = GetAllData().Find(e => e.Id == id);
            if (null != temp)
            {
                temp.Name = obj.Name;
                temp.Designation = obj.Designation;
                this.conn.SaveChanges();
                return true;
            }
            else
            { return false; }
        }

    }
}
