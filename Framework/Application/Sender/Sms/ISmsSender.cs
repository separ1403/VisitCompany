﻿namespace Framework.Application.Sender.Sms;

public interface ISmsSender
{
    Task<int> SendByKavenagarAsync(string message, string PhoneNumber);
}