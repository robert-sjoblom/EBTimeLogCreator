﻿using System;
namespace EBTimeLogCreator
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}