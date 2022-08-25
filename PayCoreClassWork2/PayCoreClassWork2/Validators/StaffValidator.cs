using FluentValidation;
using PayCoreClassWork2.Controllers;
using PayCoreClassWork2.Models;
using System.Text.RegularExpressions;

namespace PayCoreClassWork2.Validators
{
    // Personel nesnesine ait validasyon kuralları.
    // Bu kurallar FluentValidation kütüphanesinde yer alan ve generic bir sınıf olan AbstractValidator sınıfından kalıtım alınarak gerçekleştirilmiştir.
    // Generic operatörünün içine Personel(Staff) sınıfını atayarak validasyon sınıfının kurucu metodunda Personel sınıfına ait validasyon kuralları atanmıştır.
    // Aktif olabilmesi için Program.cs'in 8.satırında programa dahil edilmiştir.
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(s => s.Id) // Id alanı için validasyon kuralları.
                .NotEmpty() // Boş olamaz.
                .WithMessage("Id is required") // Eğer boş bırakılırsa gösterilecek hata mesajı.
                .Must(IsIdUnique) // Benzersiz olmak zorundadır.
                .WithMessage("This number is already in use"); // Eğer varolan bir id kullanılıyorsa gösterilecek hata mesajı.

            RuleFor(s => s.Name) // İsim alanı için validasyon kuralları.
                .Length(3, 20) // 3 ile 20 karakter arası uzunlukta olmalıdır.
                .WithMessage("Name's length must be between 3 and 20 characters"); // Eğer bu aralığın dışındaysa gösterilecek hata mesajı.

            RuleFor(s => s.LastName) // Soyad alanı için validasyon kuralları.
                .Length(3, 20) // 3 ile 20 karakter arası uzunlukta olmalıdır.
                .WithMessage("Last name's length must be between 3 and 20 characters"); // Eğer bu aralığın dışındaysa gösterilecek hata mesajı.

            RuleFor(s => s.DateOfBirth) // Doğum tarihi alanı için validasyon kuralları.
                .NotEmpty() // Boş olamaz.
                .WithMessage("Date of birth is required") // Eğer boş bırakılırsa gösterilecek hata mesajı.
                .InclusiveBetween(new(1945, 11, 11), new(2002, 10, 10)) // 11/11/1945 ve 10/10/2002 arasında olmak zorundadır.
                .WithMessage("Date is out of range. Must be between 11/11/1945 and 10/10/2002"); // Eğer bu aralığın dışındaysa gösterilecek hata mesajı.

            RuleFor(s => s.Email) // E-Posta alanı için validasyon kuralları.
                .EmailAddress() // Geçerli bir e-posta adresi olmak zorundadır.
                .WithMessage("A valid email address is required") // Eğer e-posta adresi özelliği taşımıyorsa gösterilecek hata mesajı.
                .Matches(new Regex(@"^[a-zA-Z\.@]{2,100}$")) // . ve @ dışında özel karakter veya sayı içermemeli.
                .WithMessage("Email address must not contain numbers and symbols except dot (Example: example@paycore.com)") // Eğer özel karakter veya sayı içeriyorsa gösterilecek hata mesajı.
                .Must(IsEmailUnique) // Benzersiz olmak zorundadır.
                .WithMessage("This e-mail address is already in use"); // Eğer varolan bir e-posta kullanılıyorsa gösterilecek hata mesajı.

            RuleFor(p => p.PhoneNumber) // Telefon numarası alanı için validasyon kuralları.
                .NotEmpty() // Boş olamaz.
                .WithMessage("Phone Number is required") // Eğer boş bırakılırsa gösterilecek hata mesajı.
                .Matches(new Regex(@"^\+(\d{2})\s(\d{3})\s(\d{3})\s(\d{2})\s(\d{2})")) // (+90 212 123 12 12) formatına uygun olmak zorundadır.
                .WithMessage("A valid phone number is required (Example: +90 212 123 12 12)") // Eğer bu formata uygun değilse gösterilecek hata mesajı.
                .Must(IsPhoneNumberUnique) // Benzersiz olmak zorundadır.
                .WithMessage("This phone number is already in use"); // Eğer varolan bir telefon numarası kullanılıyorsa gösterilecek hata mesajı.

            RuleFor(s => s.Salary) // Maaş alanı için validasyon kuralları.
                .NotEmpty() // Boş olamaz.
                .WithMessage("Salary is required") // Eğer boş bırakılırsa gösterilecek hata mesajı.
                .InclusiveBetween(2000.0, 9000.0) // 2000 ile 9000 arasında olmalıdır.
                .WithMessage("Salary must be between 2000 and 9000"); // Bu aralığın dışındaysa gösterilecek hata mesajı.
        }

        // Benzersiz olma durumlarında kullanılacak metodlar.
        private bool IsIdUnique(Staff staff, int newValue) => StaffController._staffList.All(s => s.Equals(staff) || s.Id != newValue);
        private bool IsEmailUnique(Staff staff, string newValue) => StaffController._staffList.All(s => s.Equals(staff) || s.Email != newValue);
        private bool IsPhoneNumberUnique(Staff staff, string newValue) => StaffController._staffList.All(s => s.Equals(staff) || s.PhoneNumber != newValue);
    }
}

/* Regex Çözümleri

   ^\+(\d{12}) ------------------------------------------> +902121231212
   ^\+(\d{2})\s(\d{3})\s(\d{3})\s(\d{2})\s(\d{2}) -------> +90 212 123 12 12 (Kullanılan)
   ^\+(\d{2})\s\((\d{3})\)\s(\d{3})\s(\d{2})\s(\d{2}) ---> +90 (212) 123 12 12
   ^[a-zA-Z\.@]{2,100}$ ---------------------------------> example@paycore.com
*/

/* Regex Notları

   (\d{}) ---> Sayısal veri anlamına gelir. Süslü parantez içinde kaç basamak olacağı belirlenebilir. Örnek: (\d{2})
   \s -------> 1 boşluk karakteri anlamına gelir.
   \ --------> Bu sembolün hemen yanına yazılan karakter yazıldığı yerde kullanılmak zorunda anlamına gelir. Örnekler: \( , \) , \+
   [] -------> Bu sembolün içerisine yazılan değerler kullanılabilecek değerleri taşır. Örnek: [a-zA-Z\.@] => Bu örnekte kullanılan ifadenin alabileceği değerler: A'dan Z'ye büyük veya küçük tüm alfabetik harfler ve nokta ile @ işaretidir. Bunlar dışında değer alamaz.
*/