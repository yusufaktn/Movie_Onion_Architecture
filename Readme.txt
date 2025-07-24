CQRS 

-Ana odağı write ve read sorumluluklarının ayrılmasıdır.
-Read tarafı sadece veri okur, yazma işlemi yapmaz.
-Write tarafı ise sadece veri yazar, okuma işlemi yapmaz.
-İki ayrı domain olarak düşünülür.Buradaki domain alan adı değildir.
-CQRS , Command Query Responsibility Segregation anlamına gelir.
-CQRS, yazma ve okuma işlemlerini ayırarak sistemin karmaşıklığını azaltmayı ve ölçeklenebilirliğini artırmayı amaçlar.
-Olası bir servis kesintisinde, okuma tarafı çalışmaya devam edebilir veya  yazma tarafı çalışmaya devam edebilir.


Command → işlem

Query → veri çekme

Handler → işi yapan yer

Result → gelen veri/Geriye dönen Response



Onion Architecture

-Onion Architecture, uygulama mimarisinde bağımlılıkları tersine çevirerek, iş mantığını ve domain modelini dış katmanlardan izole etmeyi amaçlar.
-Temel prensibi, uygulamanın iç katmanlarının dış katmanlara bağımlı olmaması ve dış katmanların iç katmanlara bağımlı olmasıdır.
-İç katmanlar, iş mantığını ve domain modelini içerirken, dış katmanlar veri erişimi, kullanıcı arayüzü ve diğer altyapı bileşenlerini içerir.

Core (Çekirdek)
	1. Domain

	Ne işe yarar?
	Uygulamanın kalbidir. Entity'ler, value object'ler, interface'ler (örneğin repository interface'leri) burada bulunur.

💡 Saf C# kodudur, hiçbir dış kütüphaneye bağımlı olmamalıdır.

	2. Application

	Ne işe yarar?
	İş kurallarını ve uygulama akışını barındırır. Use case'ler (örneğin: film ekle, film sil), servis interface'leri burada olur.

	Application layer, Domain'e bağlıdır ama dış katmanlara bağımlı değildir.

🔸 Infrastructure (Altyapı)
	3. Persistence

	Ne işe yarar?
	Veritabanı ile ilgili teknik detayların uygulandığı yerdir.

	Repository interface’lerinin implementasyonları burada yer alır.

	Entity Framework gibi ORM araçları burada kullanılır.

🔸 Presentation
	4. Api
	
	Ne işe yarar?
	Kullanıcıdan veya başka sistemlerden gelen HTTP isteklerini karşılayan katmandır.

	Controller'lar burada yer alır.

	Genelde ASP.NET Core Web API projesidir.

🔸 Frontends (isteğe bağlı)
	Ne işe yarar?
	Eğer projede frontend (örneğin Blazor, React) kullanılıyorsa bu klasörde yer alır.
	Sunum arayüzlerini içerir.



AddScoped , AddSingleton ,AddTransient

-AddScoped: "Her kullanıcı isteğinde bir tane oluştur, sonra sil."

-AddSingleton: "Uygulama açıldığında bir tane oluştur, hep onu kullan."

-AddTransient: "Her kullanımda yeni oluştur."

-Mesela, CreateMovieCommandHandler içinde geçici olarak tutulan veriler (örn. işlem sırasında toplanan bilgiler) sadece o kullanıcı isteğine özel olur.

-Eğer Singleton olsaydı, bütün kullanıcılar aynı örneği paylaşırdı, ki bu istenmeyen karışıklıklara neden olur.

-Eğer Transient olsaydı, her kullanımda yeni örnek olur, bazen da yönetilmesi zor olabilir.


Mediator:

Mediator (Arabulucu) Tasarım Deseni, nesneler arasındaki karmaşık iletişimi merkezi bir arabulucu nesnesi üzerinden yönetir. 
Böylece nesneler doğrudan birbirleriyle iletişim kurmak yerine, arabulucuya mesaj gönderir ve arabulucu bu mesajı ilgili nesneye iletir. 
Bu desen, nesneler arasındaki bağımlılığı azaltır, kodun okunabilirliğini ve bakımını kolaylaştırır. 
Özellikle çok sayıda nesnenin birbiriyle etkileşimde olduğu durumlarda tercih edilir.