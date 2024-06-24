using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniTutor.DataBase;
using UniTutor.Interface;
using UniTutor.Model;

namespace UniTutor.Repository
{
    public class StudentRepository : IStudent
    {
        private ApplicationDBContext _DBcontext;
        private readonly IConfiguration _config;
        private readonly Cloudinary _cloudinary;
        public StudentRepository(ApplicationDBContext DBcontext , IConfiguration config)
        {
            _DBcontext = DBcontext;
            
        }
        public bool SignUp(Student student)
        {
            try
            {
              PasswordHash ph = new PasswordHash();
              student.password = ph.HashPassword(student.password);
                _DBcontext.Students.Add(student);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool Login(string email, string password)
        {
            try
            {
                var student = _DBcontext.Students.FirstOrDefault(a => a.Email == email);

                if (student == null)
                {
                    Console.WriteLine("Student not found.");
                    return false;
                }

                PasswordHash ph = new PasswordHash();

                bool isValidPassword = ph.VerifyPassword(password, student.password);

                return isValidPassword;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"InvalidCastException: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General exception: {ex.Message}");
                throw;
            }
        }

        public Student GetByMail(string Email)
        {
            return _DBcontext.Students.FirstOrDefault(s => s.Email == Email);
        }
        public bool Delete(int id)
        {
            var student = _DBcontext.Students.Find(id);
            if (student != null)
            {
                _DBcontext.Students.Remove(student);
                _DBcontext.SaveChanges();
                return true;
            }
            return false;
        }
        public Student GetById(int id)
        {
            return _DBcontext.Students.Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _DBcontext.Students.ToList();
        }

       

        
        public bool SignOut()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    
        public bool CreateRequest(Request request)
        {
            try
            {
                _DBcontext.Request.Add(request);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteRequest(Request request) 
        {
            try
            {
                _DBcontext.Request.Remove(request);
                _DBcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       

        public async Task<bool> Update(Student student)
        {
            _DBcontext.Students.Update(student);
            return await _DBcontext.SaveChangesAsync() > 0;
        }


    }
}
