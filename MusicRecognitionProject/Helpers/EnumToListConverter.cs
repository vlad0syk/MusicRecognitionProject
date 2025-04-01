using MusicRecognitionProject.Models.Enums;

namespace MusicRecognitionProject.Helpers
{
    public static class EnumToListConverter
    {
	    public static List<string> ConvertPlatformsEnumToList()
	    {
		    return ConvertEnumToList(typeof(Platforms));
	    }
		private static List<string> ConvertEnumToList(Type enumType)
		{
			return Enum.GetNames(enumType).ToList();
		}
	}
}
