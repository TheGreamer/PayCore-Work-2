namespace PayCoreClassWork2.Models
{
    // Personel nesnesi.
    // Bu nesneye ait validasyon kuralları Validators klasörünün altındaki StaffValidator sınıfında FluentValidation kullanılarak belirlendi.
    public class Staff
    {
        // Personel nesnesine ait kurucu metod. İçerisinde personel nesnesine ait propertylere parametreler aracılığıyla atama yapıldı.
        // Program ilk derlendiğinde StaffController'in kurucu metodunda hazır veriler oluşturulması için bu kurucu metoda başvuruldu.
        public Staff(int id, string name, string lastName, DateTime dateOfBirth, string email, string phoneNumber, double salary)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Salary = salary;
        }

        public int Id { get; set; } // Id özelliği (Tam sayı)
        public string Name { get; set; } // Ad özelliği (Metinsel)
        public string LastName { get; set; } // Soyad özelliği (Metinsel)
        public DateTime DateOfBirth { get; set; } // Doğum tarihi özelliği (Tarih)
        public string Email { get; set; } // E-posta özelliği (Metinsel)
        public string PhoneNumber { get; set; } // Telefon numarası özelliği (Metinsel)
        public double Salary { get; set; } // Maaş özelliği (Ondalıklı sayı)
    }
}