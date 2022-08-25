using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork2.Models;

namespace PayCoreClassWork2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        // Statik bir personel listesi tanımlanır.
        public static List<Staff> _staffList = new();
        
        // Kurucu metod.
        public StaffController()
        {
            // Eğer personel listesinde eleman yoksa test verileri oluşması için liste 4 elemanla beraber yeniden oluşturulur.
            if (_staffList.Count == 0)
            {
                _staffList = new()
                {
                    // Elemanların oluşturulmasında listeye ekleme yaparak eklemektense personel sınıfına ait kurucu metod kullanıldı.
                    new(0, "Bill", "Henrickson", new(1966, 12, 17), "bill.hendrickson@outlook.com", "+905229642953", 8000.0),
                    new(1, "Francis", "Holland", new(1984, 6, 14), "francis.holland@outlook.com", "+905439425596", 7000.0),
                    new(2, "Zoey", "Hensburg", new(1995, 11, 25), "zoey.hensburg@outlook.com", "+905336504922", 7000.0),
                    new(3, "Louis", "Vellbon", new(1988, 5, 12), "louis.vellbon@outlook.com", "+905323521105", 6000.0)
                };
            }
        }

        // Tüm personel listesi çağırılır.
        [HttpGet]
        public List<Staff> Get() => _staffList;

        // Id'ye göre personel araması yapılır.
        [HttpGet("{id}")]
        public ActionResult<Staff> GetById(int? id) => SearchById(id);

        // Personel listesine ekleme yapılır.
        [HttpPost]
        public ActionResult Post([FromBody] Staff staff)
        {
            if (ModelState.IsValid) // Eğer personel nesnesine ait veri işlemi validasyona uygunsa
            {
                _staffList.Add(staff); // Personel listesine ekleme yapılır.
                return Ok(); // 200 kodlu başarılı bilgisi döndürülür.
            }

            return BadRequest(); // Aksi durumda 400 hata kodlu "Geçersiz İstek" hatası döndürülür.
        }

        // Personel listesinde id'ye göre güncelleme yapılır.
        [HttpPut("{id}")]
        public ActionResult Put(int? id, [FromBody] Staff staff)
        {
            var staffToUpdate = SearchById(id); // Id'ye göre arama yapılır ve hata durumunda NonAction metod içindeki dönüş tiplerinden uygun olan döndürülür.

            if (ModelState.IsValid) // Eğer personel nesnesine ait veri işlemi validasyona uygunsa
            {
                // Body'den gönderilen bilgiler id'si seçilmiş olan personelin bilgileriyle güncellenir.
                staffToUpdate.Value.Name = staff.Name;
                staffToUpdate.Value.LastName = staff.LastName;
                staffToUpdate.Value.DateOfBirth = staff.DateOfBirth;
                staffToUpdate.Value.Email = staff.Email;
                staffToUpdate.Value.PhoneNumber = staff.PhoneNumber;
                staffToUpdate.Value.Salary = staff.Salary;

                return Ok(); // 200 kodlu başarılı bilgisi döndürülür.
            }

            return BadRequest(); // Aksi durumda 400 hata kodlu "Geçersiz İstek" hatası döndürülür.
        }

        // Personel listesinden id'ye göre kaldırma işlemi yapılır.
        [HttpDelete("{id}")]
        public ActionResult Delete(int? id)
        {
            var staff = SearchById(id).Value; // Id'ye göre arama yapılır ve hata durumunda NonAction metod içindeki dönüş tiplerinden uygun olan döndürülür.

            if (staff == null) // Yapılan aramaya dair kayıt yoksa
                return NotFound(); // 404 hata kodlu "Bulunamadı" hataso döndürülür.

            _staffList.Remove(staff); // Arama sonucunda bir kayıt bulunduysa bu kayıt listeden silinir.
            return Ok(); // 200 kodlu başarılı bilgisi döndürülür.
        }

        // 3 farklı action metodunda Id'ye göre personel arama işlemine ihtiyaç olmasından ötürü bu işlem
        // action olarak sayılmayan ve sadece metod görevi gören bir NonAction metoda yazılmıştır. Böylece
        // kod tekrarından uzak durulmuştur.
        [NonAction]
        public ActionResult<Staff> SearchById(int? id)
        {
            if (id == null) // Eğer parametreden gelen id null ise
                return BadRequest(); // 400 hata kodlu "Geçersiz İstek" hatası döndürülür.

            var staff = _staffList.FirstOrDefault(s => s.Id == id); // Id null değil ise personel listesinde parametreye gönderilen Id'ye göre arama yapılır.

            if (staff == null) // Eğer yapılan arama sonucunda bir kayıt bulunamadıysa
                return NotFound(); // 404 hata kodlu "Bulunamadı" hatası döndürülür.

            return staff; // Eğer bir kayıt bulunduysa bu kayıt döndürülür.
        }
    }
}