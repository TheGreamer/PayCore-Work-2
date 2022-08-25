<i>PayCore .NET Core Bootcamp - 2. Hafta</i>
<hr />
<h3>Görev Listesi</h4>
<ul>
<li>
<a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta2/blob/main/PayCoreClassWork2/PayCoreClassWork2/Models/StaffFluent.cs" target="_blank"><b>Staff.cs</b></a>
</li>
<li>
<a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta2/blob/main/PayCoreClassWork2/PayCoreClassWork2/Validators/StaffValidator.cs" target="_blank"><b>StaffValidator.cs</b></a>
</li>
<li>
<a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta2/blob/main/PayCoreClassWork2/PayCoreClassWork2/Utilities/DateTimeConverter.cs" target="_blank"><b>DateTimeConverter.cs</b></a>
</li>
<li>
<a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta2/blob/main/PayCoreClassWork2/PayCoreClassWork2/Program.cs" target="_blank"><b>Program.cs</b></a>
</li>
<li>
<dl>
<dt><a href="https://github.com/195-Patika-Dev-Paycore-Net-Bootcamp/gokay_urenc_hafta2/blob/main/PayCoreClassWork2/PayCoreClassWork2/Controllers/StaffController.cs" target="_blank">StaffController.cs</a></dt>
<br/ >
<dd>[HttpGet] Get()</dd>
<dd>[HttpGet] GetById(int?)</dd>
<dd>[HttpPost] Post(Staff)</dd>
<dd>[HttpPut] Put(int?, Staff)</dd>
<dd>[HttpDelete] Delete(int?)</dd>
<dd>[NonAction] SearchById(int?)</dd>
<dd><p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/nzjefhb.png" alt="Swagger" style="max-width: 100%;"></a></p></dd>
</dl>
</li>
</ul>
<hr />
<h3><b>Sonuçlara Ait Ekran Görüntüleri</b></h2>
<ul>
<li>
<h4>Personel Listesinin Tamamını Listeleme : [HttpGet] Get()</h4>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/kautsd3.png" alt="Swagger" style="max-width: 100%;"></a></p>
</li>
<li>
<h4>ID'ye Göre Personel Aratma : [HttpGet] GetById(int?)</h4>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/s1259ti.png" alt="Swagger" style="max-width: 100%;"></a></p>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/ig6rdlr.png" alt="Swagger" style="max-width: 100%;"></a></p>
</li>
<li>
<h4>Personel Listesine Veri Ekleme : [HttpPost] Post(Staff)</h4>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/jwt9imm.png" alt="Swagger" style="max-width: 100%;"></a></p>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/rzhld2c.png" alt="Swagger" style="max-width: 100%;"></a></p>
</li>
<li>
<h4>Personel Listesinde ID'ye Göre Veri Güncelleme : [HttpPut] Put(int?, Staff)</h4>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/ct11gly.png" alt="Swagger" style="max-width: 100%;"></a></p>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/ds8033i.png" alt="Swagger" style="max-width: 100%;"></a></p>
</li>
<li>
<h4>Personel Listesinden ID'ye Göre Veri Silme : [HttpDelete] Delete(int?)</h4>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/acg0tbv.png" alt="Swagger" style="max-width: 100%;"></a></p>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/6juufcu.png" alt="Swagger" style="max-width: 100%;"></a></p>
</li>
<li>
<h4>Nesne Şeması</h4>
<p dir="auto"><a target="_blank" rel="noopener noreferrer" href=""><img src="https://i.hizliresim.com/mzdnrsu.png" alt="Swagger" style="max-width: 100%;"></a></p>
</li>
</ul>
<hr />
<b>Regex Notları</b>
<ul>
<br />
<li>
<b>(\d{})</b> : Sayısal veri anlamına gelir. Süslü parantez içinde kaç basamak olacağı belirlenebilir. Örnek: (\d{2})
</li>
<li>
<b>\s</b> : 1 boşluk karakteri anlamına gelir.
</li>
<li>
<b>\</b> : Bu sembolün hemen yanına yazılan karakter yazıldığı yerde kullanılmak zorunda anlamına gelir. Örnekler: \( , \) , \+
</li>
<li>
<b>[]</b> : Bu sembolün içerisine yazılan değerler kullanılabilecek değerleri taşır. Örnek: [a-zA-Z\.@] => Bu örnekte kullanılan ifadenin alabileceği değerler: A'dan Z'ye büyük veya küçük tüm alfabetik harfler ve nokta ile @ işaretidir. Bunlar dışında değer alamaz.
</li>
</ul>
<hr />
<b>Regex Çözümleri</b>
<ul>
<br />
<li><b>^\+(\d{12})</b> : +902121231212</li>
<li><b>^\+(\d{2})\s(\d{3})\s(\d{3})\s(\d{2})\s(\d{2})</b> : +90 212 123 12 12 (Kullanılan)</li>
<li><b>^\+(\d{2})\s\((\d{3})\)\s(\d{3})\s(\d{2})\s(\d{2})</b> : +90 (212) 123 12 12</li>
<li><b>^[a-zA-Z\.@]{2,100}$</b> : example@paycore.com</li>
</ul>
