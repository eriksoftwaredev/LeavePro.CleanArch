﻿namespace LeavePro.CleanArch.BlazorUI.Services.Base;

public partial interface IClient
{
    public HttpClient HttpClient { get; }
}