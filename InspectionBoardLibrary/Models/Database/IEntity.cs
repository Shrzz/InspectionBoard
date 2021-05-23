using System;

namespace InspectionBoardLibrary.Models.Database
{
    public interface IEntity
    {
        int Id { get; set; }

        string GetShortDescription();

        string GetFullDescription();

        string GetValidString(IEntity o, string empty, string propName);
    }
}
