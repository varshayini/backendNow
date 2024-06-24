﻿using Azure.Core;
using UniTutor.Model;

namespace UniTutor.Interface
{
    public interface IStudent
    {
        public bool SignUp(Student student);
        public bool Login(string email, string password);
        public Student GetByMail(string Email);
        // for delete 
        bool Delete(int id);
        Student GetById(int id);
        IEnumerable<Student> GetAll();
        public bool SignOut();
        public bool CreateRequest(Model.Request request);
        public bool DeleteRequest(Model.Request request);
        public Task<bool> Update(Student student);


        // public string UploadFile(IFormFile file);
        // public bool UpdateStudent(Student student, IFormFile ProfileImage);


    }
}
