// Interface định nghĩa các chức năng của dịch vụ
public interface IMessageServiceAlter
{
	void SendMessage(string message);
}

// Lớp cài đặt interface IMessageService
public class EmailService : IMessageServiceAlter
{
	public void SendMessage(string message)
	{
		Console.WriteLine("Sending email: " + message);
	}
}

public class SmsService : IMessageServiceAlter
{
	public void SendMessage(string message)
	{
		Console.WriteLine("Sending SMS: " + message);
	}
}

// Lớp phụ thuộc vào IMessageService
public class Notification
{
	private readonly IMessageServiceAlter _messageService;
	//_messageService sẽ nhận giá trị là một instance của class cài đặt IMessageService (ví dụ: EmailService)


	// Tiêm phụ thuộc thông qua constructor
	public Notification(IMessageServiceAlter messageService)
	{
		_messageService = messageService;
	}

	public void Send(string message)
	{
		_messageService.SendMessage(message);
	}
}

// Chương trình chính
class Program
{
	static void Main(string[] args)
	{
		// Tạo một đối tượng của EmailService
		IMessageServiceAlter emailService = new EmailService();

		// Tiêm EmailService vào lớp Notification
		Notification notification = new Notification(emailService);

		// Gửi thông báo
		notification.Send("Hello, Dependency Injection!");


		IMessageServiceAlter smsService = new SmsService();

		Notification notification1 = new Notification(smsService);
		
		notification1.Send("Hello, Dependency Injection!");
	}
}

// Như vậy Dependency Injection giúp class Notification có thể tùy biến thay vì phụ thuộc hoàn toàn
// vào class EmailService.
// Hay có thể nói ta có thể thêm biến cho class