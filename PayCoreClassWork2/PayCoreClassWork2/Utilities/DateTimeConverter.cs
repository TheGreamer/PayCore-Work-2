using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayCoreClassWork2.Utilities
{
    // Bu sınıf action metodların çalıştırılması anında gözüken DateTime tipindeki Json'un format biçimini değiştirmeye yarar.
    // Aktif olabilmesi için Program.cs'in 9.satırında programa dahil edilmiştir.
    // Kalıtım alınan generic bir yapıya sahip olan JsonConverter sınıfının mevcutta yer alan soyut metodları biçimlendirilerek format ayarları uygulanmıştır.
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => DateTime.Parse(reader.GetString());

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToLocalTime().ToString("yyyy-MM-dd"));
    }
}