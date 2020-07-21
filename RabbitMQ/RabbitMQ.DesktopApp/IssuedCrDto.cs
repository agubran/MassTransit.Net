using System;
using System.Collections.Generic;

namespace eBusiness.NewCR
{
    public class IssuedCrDto
    {
        public string ReferenceId { get; set; }
        public string SysRef { get; set; }
        public Guid? SystemReference { get; set; }
        public string SystemDesc { get; set; }
        public IssuedCrDetailsDto IssuedCrDetails { get; set; }
        public List<PartiesDto> Parties { get; set; }
    }

    public class IssuedCrDetailsDto
    {
        public string CRNumber { get; set; }
        public string NationalNumber { get; set; }
        public string RecieptNo { get; set; }
        public DateTime RecieptDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CrName { get; set; }
        public int? ContractNumber { get; set; }
        public string FileNo { get; set; }
        public bool IsMain { get; set; }
        public string MainCRNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? EstCapial { get; set; }
        public double? AnnouncedCapital { get; set; }
        public double? SubsicribedCapital { get; set; }
        public double? PaidCapital { get; set; }
        public int? Shares { get; set; }
        public double? SharePrice { get; set; }
        public int? SharePercentage { get; set; }
        public string FlatActivities { get; set; }
        public int? CompanyPeriod { get; set; }
        public DateTime? CompanyPeriodFrom { get; set; }
        public DateTime? CompanyPeriodTo { get; set; }
        public DateTime? FoundationLicenseDecisionDate { get; set; }
        public string FoundationLicenseDecisionSourceID { get; set; }
        public string InvestmentDecisionNumber { get; set; }
        public DateTime? InvestmentDecisionDate { get; set; }
        public string InvestmentDecisionSourceID { get; set; }
        public string FoundationDeclarationDecisionNumber { get; set; }
        public DateTime? FoundationDeclarationDecisionDate { get; set; }
        public string FoundationDeclarationDecisionSourceID { get; set; }
        public DateTime? UmmulQuraNumberDate { get; set; }
        public string UmmulQuraNumber { get; set; }
        public CrTradeNameDto CrTradeName { get; set; }
        public int? FiscalDay { get; set; }
        public int? FiscalMonth { get; set; }
        public FiscalCalendarType? FiscalYearType { get; set; }
        public List<ActivityDto> Activities { get; set; }
        public List<LicenseDto> Licenses { get; set; }
        public AddressDto Address { get; set; }
        public NationalityDto Nationality { get; set; }
        public CurrencyDto Currency { get; set; }
        public LocationDto Location { get; set; }
        public BusinessTypeDto BusinessType { get; set; }
    }

    public class PartiesDto
    {
        public string Name { get; set; }
        public DateTime? RelationFrom { get; set; }
        public DateTime? RelationTo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthLocation { get; set; }
        public int? GrossAmount { get; set; }
        public int? Shares { get; set; }
        public int? SharePercentage { get; set; }
        public string Privliges { get; set; }
        public string Prohibitions { get; set; }

        //suppose to be list
        public List<IdentifierDto> Identifiers { get; set; }

        public AddressDto Address { get; set; }
        public RelationTypeDto RelationType { get; set; }
        public NationalityDto Nationality { get; set; }
        public PartyTypeDto PartyType { get; set; }
    }

    public enum FiscalCalendarType
    {
        Hijri = 1,
        Georgian = 2
    }

    public class CrTradeNameDto
    {
        public int NamingMethodID { get; set; } // we need to send enum in document file

        public string ReservedNameReferenceNumber { get; set; }

        public string BusinessEntityTradeName { get; set; }

        public string ActiveNameCrNumber { get; set; }

        public CrTypeDto CrType { get; set; }

        public ActivityTypeDto ActivityType { get; set; }
    }

    public class ActivityTypeDto
    {
        public int? ActivityTypeID { get; set; }
        public string Description { get; set; }
    }

    public class CrTypeDto
    {
        public int? CrTypeID { get; set; }
        public string Description { get; set; }
    }

    public class ActivityDto
    {
        public string ActivityID { get; set; }
        public string Description { get; set; }
        public string ParentID { get; set; }
        public int? Gender { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
        public bool IsRequiredLicense { get; set; }
        public AuthorityDto Authority { get; set; }
        public ActivityDto Parent { get; set; }
    }

    public class AuthorityDto
    {
        public int AuthorityID { get; private set; }
        public string Name { get; private set; }
        public bool IsCancelRequired { get; private set; }
    }

    public class LicenseDto
    {
        public string LicenseNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ExpiaryDate { get; set; }
        public string Description { get; set; }
        public AuthorityDto Authority { get; set; }
    }

    public class AddressDto
    {
        public string Description { get; set; }
        public string PostalCode { get; set; }
        public string PoBox1 { get; set; }
        public string PoBox2 { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Fax1 { get; set; }

        public string Fax2 { get; set; }

        public string Telex1 { get; set; }

        public string Telex2 { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Website { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public bool IsWasel { get; set; }

        public string WaselStreetName { get; set; }

        public string WaselBuildingNumber { get; set; }

        public string WaselAdditionalNumber { get; set; }

        public string WaselCity { get; set; }

        public string WaselUnitNumber { get; set; }

        public DistrictDto District { get; set; }
    }

    public class DistrictDto
    {
        public string ArabicName { get; set; }

        public string EnglishName { get; set; }
    }

    public class NationalityDto
    {
        public string NationalityID { get; set; }

        public string Name { get; set; }

        public string NICCode { get; set; }

        public bool? IsSaudi { get; set; }

        public bool? IsGulf { get; set; }
    }

    public class CurrencyDto
    {
        public string CurrencyID { get; set; }
        public string Name { get; set; }
    }

    public class LocationDto
    {
        public string LocationID { get; private set; }
        public string ArabicName { get; private set; }
        public string EnglishName { get; private set; }
    }

    public class BusinessTypeDto
    {
        public string BusinessTypeID { get; private set; }
        public string Name { get; private set; }
    }

    public class IdentifierDto
    {
        public string Number { get; set; }
        public string IssuePlace { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiaryDate { get; set; }
        public IdentifierTypeDto IdentifierType { get; set; }
    }

    public class IdentifierTypeDto
    {
        public int IdentifierTypeID { get; set; }
        public string Name { get; set; }
    }

    public class RelationTypeDto
    {
        public string RelationTypeID { get; set; }
        public string Name { get; set; }
    }

    public class PartyTypeDto
    {
        public int PartyTypeID { get; private set; }
        public string Name { get; private set; }
    }
}