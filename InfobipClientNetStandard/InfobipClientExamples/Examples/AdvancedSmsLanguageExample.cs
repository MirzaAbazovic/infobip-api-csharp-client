﻿using Infobip.Api.Model;
using Infobip.Api.Model.Sms.Mt.Send;
using Infobip.Api.Model.Sms.Mt.Send.Textual;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infobip.Api.Client.Examples
{
    class AdvancedSmsLanguageExample : Example
    {
        public override async Task RunExampleAsync()
        {
            string messageId = await AdvancedSmsAsync();

            System.Threading.Thread.Sleep(2000);

            await GetSmsReportAsync(messageId);
        }

        private static async Task<string> AdvancedSmsAsync()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Sending fully featured textual message with language...");

            SendMultipleTextualSmsAdvanced smsClient = new SendMultipleTextualSmsAdvanced(BASIC_AUTH_CONFIGURATION);

            Destination destination = new Destination
            {
                To = TO
            };

            Language language = new Language
            {
                LanguageCode = "TR",
                SingleShift = true,
                LockingShift = true
            };

            Message message = new Message
            {
                From = FROM,
                Destinations = new List<Destination>(1) { destination },
                Text = "Artık Ulusal Dil Tanımlayıcısı ile Türkçe karakterli smslerinizi rahatlıkla iletebilirsiniz.",
                Language = language,
                Transliteration = "TURKISH"
            };

            SMSAdvancedTextualRequest request = new SMSAdvancedTextualRequest
            {
                Messages = new List<Message>(1) { message }
            };

            SMSResponse smsResponse = await smsClient.ExecuteAsync(request);

            Console.WriteLine("Sending fully featured textual message with language complete.");

            SMSResponseDetails sentMessageInfo = smsResponse.Messages[0];
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Message ID: " + sentMessageInfo.MessageId);
            Console.WriteLine("Receiver: " + sentMessageInfo.To);
            Console.WriteLine("Message status: " + sentMessageInfo.Status.Name);
            Console.WriteLine("-------------------------------");

            return sentMessageInfo.MessageId;
        }
    }
}
