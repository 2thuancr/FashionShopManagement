﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using DAO;
using DTO;

namespace BUS
{
    public class CustomerBUS
    {
        private static CustomerBUS instance;

        public static CustomerBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerBUS();
                return CustomerBUS.instance;
            }
        }

        private CustomerBUS() { }


        public List<Customer> GetAllCustomer() 
        {
            DataTable table;
            try
            {
                table = CustomerDAO.Instance.GetAllCustomer();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            List<Customer> listCustomer = new List<Customer>();
            foreach (DataRow row in table.Rows) 
            {
                Customer customer = new Customer(row);
                listCustomer.Add(customer);
            }
            return listCustomer;
        }

        /// <summary>
        /// Lấy danh sách khách hàng từ số điện thoại
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomerByPhone(string phoneNumber)
        {
            DataTable table;
            try
            {
                table = CustomerDAO.Instance.GetCustomerByPhone(phoneNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            List<Customer> listCustomer = new List<Customer>();
            foreach (DataRow row in table.Rows)
            {
                Customer customer = new Customer(row);
                listCustomer.Add(customer);
            }
            return listCustomer;
        }
        public Customer GetCustomerById(int customerId)
        {
            DataTable table;
            try
            {
                table = CustomerDAO.Instance.GetCustomerById(customerId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Customer customer = new Customer();
            if (table != null && table.Rows.Count > 0)
            {
                customer = new Customer(table.Rows[0]);
            }
            return customer;
        }
    }
}