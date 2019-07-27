using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pradeepm.Models.DB
{
    public partial class AccountUsers
    {
        public AccountUsers()
        {
            Income = new HashSet<Income>();
            NominiDetails = new HashSet<NominiDetails>();
            Otps = new HashSet<Otps>();
            Payout = new HashSet<Payout>();
            PinOrders = new HashSet<PinOrders>();
            PinTransfersFromUser = new HashSet<PinTransfers>();
            PinTransfersToUser = new HashSet<PinTransfers>();
            PinsForUserNavigation = new HashSet<Pins>();
            PinsUsedByNavigation = new HashSet<Pins>();
            PrasnalDetails = new HashSet<PrasnalDetails>();
            UserBankDetails = new HashSet<UserBankDetails>();
            UserClosing = new HashSet<UserClosing>();
            UserLogins = new HashSet<UserLogins>();
        }

        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("AccountID")]
        [StringLength(20)]
        public string AccountId { get; set; }
        [StringLength(20)]
        public string Password { get; set; }
        [Column("TPassword")]
        [StringLength(20)]
        public string Tpassword { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string DisplayName { get; set; }
        [Column("SponserID")]
        public int SponserId { get; set; }
        [Column("FatherID")]
        public int FatherId { get; set; }
        public byte Side { get; set; }
        [Column("ProductID")]
        public byte ProductId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal JoiningAmount { get; set; }
        [Required]
        public bool? Activate { get; set; }
        public bool FirstLogin { get; set; }
        [Required]
        public bool? Topup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TopupDate { get; set; }
        public bool? SuperUser { get; set; }
        [Required]
        public bool? Status { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("AccountUsers")]
        public Products Product { get; set; }
        [InverseProperty("User")]
        public ICollection<Income> Income { get; set; }
        [InverseProperty("AccountUser")]
        public ICollection<NominiDetails> NominiDetails { get; set; }
        [InverseProperty("User")]
        public ICollection<Otps> Otps { get; set; }
        [InverseProperty("User")]
        public ICollection<Payout> Payout { get; set; }
        [InverseProperty("OrderByUser")]
        public ICollection<PinOrders> PinOrders { get; set; }
        [InverseProperty("FromUser")]
        public ICollection<PinTransfers> PinTransfersFromUser { get; set; }
        [InverseProperty("ToUser")]
        public ICollection<PinTransfers> PinTransfersToUser { get; set; }
        [InverseProperty("ForUserNavigation")]
        public ICollection<Pins> PinsForUserNavigation { get; set; }
        [InverseProperty("UsedByNavigation")]
        public ICollection<Pins> PinsUsedByNavigation { get; set; }
        [InverseProperty("AccountUser")]
        public ICollection<PrasnalDetails> PrasnalDetails { get; set; }
        [InverseProperty("AccountUser")]
        public ICollection<UserBankDetails> UserBankDetails { get; set; }
        [InverseProperty("User")]
        public ICollection<UserClosing> UserClosing { get; set; }
        [InverseProperty("AccountUser")]
        public ICollection<UserLogins> UserLogins { get; set; }
    }
}
