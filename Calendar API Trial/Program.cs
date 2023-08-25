using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalendarAPI;

class Program
{
	static void Main(string[] args)
	{
		ServiceAccountCredential credential = ServiceAccount.GenerateCredential();
		CalendarService service = CalendarManager.GenerateService(credential);

		Calendar calendar = CalendarManager.GenerateCalendar(service,Rooms.GetRoomLink(1));
		Events events = CalendarManager.MakeRequest(service, calendar);
		List<Event> allEvents = CalendarManager.GetEventList(events);
		
		CalendarManager.ListingEvents(allEvents);
		Console.Read();

		var startDate = new DateTime(2023, 08, 26, 15, 30, 0);
		var endDate = new DateTime(2023, 08, 26, 16, 30, 0);
		
		// string startRCF = startDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
		string startRCF = startDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.DateTimeFormatInfo.InvariantInfo);
		Console.WriteLine(startRCF);
		// string endRCF = endDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
		string endRCF = endDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.DateTimeFormatInfo.InvariantInfo);
		Console.WriteLine(endRCF);

		CalendarManager.CreateEvent(
			service,
			calendar,
			"Bootcamp Formulatrix Batch 3",
			"Salatiga",
			"Learning about .NET framework",
			new EventDateTime()
			{
				// DateTimeDateTimeOffset = new DateTime(2023, 08, 26, 15, 30, 0),
				// DateTimeRaw = "2023-08-26T14:30:00.000Z",
				DateTimeRaw = startRCF,
				TimeZone = "Asia/Jakarta"
			},
			new EventDateTime()
			{
				// DateTimeDateTimeOffset = new DateTime(2023, 08, 26, 16, 30, 0),
				// DateTimeRaw = "2023-08-26T15:30:00.000Z",
				DateTimeRaw = endRCF,
				TimeZone = "Asia/Jakarta"
			}
		);
	}
}





