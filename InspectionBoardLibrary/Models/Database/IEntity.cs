using System;

namespace InspectionBoardLibrary.Models.Database
{
    public interface IEntity
    {
        int Id { get; set; }

        string GetDescription();

        string GetValidString(IEntity o, string empty, string propName);
    }
}
