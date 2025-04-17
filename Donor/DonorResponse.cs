using System;

public class DonorResponse
{
    public string DonorId { get; set; } = string.Empty;
    public string IdNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }       
    public string PreferredPanelCode { get; set; } = string.Empty;
    public string DonorCode { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string CellPhone { get; set; } = string.Empty;
    public string HomePhone { get; set; } = string.Empty;
    public string WorkPhone { get; set; } = string.Empty;
    public int Status { get; set; } = int.MaxValue;
    public int MalariaStatus { get; set; } 
    public string Email { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string BloodType { get; set; } = string.Empty;
    public int Bfreq { get; set; }
    public bool ForeignDonor { get; set; }
    public DateTime LastDonationDate { get; set; }
    public DateTime NextDonationDate { get; set; }
    public int NumberOfDonations { get; set; }
    public string LastDonationArea { get; set; } = string.Empty;
    public string LastDonationType { get; set; } = string.Empty;
    public int UnitsDonatedToDate { get; set; }
    public bool TherapeuticDonor { get; set; }
    public Address Address { get; set; }
    public CommunicationSetting CommunicationSetting { get; set; }                
}

public class Address
{
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; } = string.Empty;
    public string AddressLine3 { get; set; }
    public string AddressLine4 { get; set; } = string.Empty;
    public string PostalCode { get; set; }
}

public class CommunicationSetting
{
    public bool SmsCommunication { get; set; }
    public bool EmailCommunication { get; set; }
    public bool PhoneCommunication { get; set; }
    public bool WhatsAppCommunication { get; set; }
}
