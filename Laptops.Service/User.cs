//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laptops.Service
{
    using System;
    using System.Collections.Generic;using PrismLaptopManager.Infrastructure;
    
    public partial class User : ViewModelBase
    {
        private string _sOEID;
    	public string SOEID 
    	{ 
    		get { return _sOEID; } 
    		set
    		{
    			if (value != _sOEID) {
    				_sOEID = value;
    				 OnPropertyChanged("SOEID");
    			}
    		} 
    	}
    
        private string _forename;
    	public string Forename 
    	{ 
    		get { return _forename; } 
    		set
    		{
    			if (value != _forename) {
    				_forename = value;
    				 OnPropertyChanged("Forename");
    			}
    		} 
    	}
    
        private string _surname;
    	public string Surname 
    	{ 
    		get { return _surname; } 
    		set
    		{
    			if (value != _surname) {
    				_surname = value;
    				 OnPropertyChanged("Surname");
    			}
    		} 
    	}
    
        private string _status;
    	public string Status 
    	{ 
    		get { return _status; } 
    		set
    		{
    			if (value != _status) {
    				_status = value;
    				 OnPropertyChanged("Status");
    			}
    		} 
    	}
    
        private string _officer_Title;
    	public string Officer_Title 
    	{ 
    		get { return _officer_Title; } 
    		set
    		{
    			if (value != _officer_Title) {
    				_officer_Title = value;
    				 OnPropertyChanged("Officer_Title");
    			}
    		} 
    	}
    
        private string _job_Title;
    	public string Job_Title 
    	{ 
    		get { return _job_Title; } 
    		set
    		{
    			if (value != _job_Title) {
    				_job_Title = value;
    				 OnPropertyChanged("Job_Title");
    			}
    		} 
    	}
    
        private string _department;
    	public string Department 
    	{ 
    		get { return _department; } 
    		set
    		{
    			if (value != _department) {
    				_department = value;
    				 OnPropertyChanged("Department");
    			}
    		} 
    	}
    
        private string _dept_Name;
    	public string Dept_Name 
    	{ 
    		get { return _dept_Name; } 
    		set
    		{
    			if (value != _dept_Name) {
    				_dept_Name = value;
    				 OnPropertyChanged("Dept_Name");
    			}
    		} 
    	}
    
        private string _business;
    	public string Business 
    	{ 
    		get { return _business; } 
    		set
    		{
    			if (value != _business) {
    				_business = value;
    				 OnPropertyChanged("Business");
    			}
    		} 
    	}
    
        private string _sector;
    	public string Sector 
    	{ 
    		get { return _sector; } 
    		set
    		{
    			if (value != _sector) {
    				_sector = value;
    				 OnPropertyChanged("Sector");
    			}
    		} 
    	}
    
        private string _city;
    	public string City 
    	{ 
    		get { return _city; } 
    		set
    		{
    			if (value != _city) {
    				_city = value;
    				 OnPropertyChanged("City");
    			}
    		} 
    	}
    
    }
}