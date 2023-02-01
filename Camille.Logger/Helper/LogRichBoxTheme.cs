namespace Camille.Logger.Helper;

public static class ConsoleHtmlColor
{
    private static readonly object SyncLock = new();

    static ConsoleHtmlColor()
    {
        lock (SyncLock)
        {
            Black = "#000000";
            DarkBlue = "#000080";
            DarkGreen = "#008000";
            DarkCyan = "#008080";
            DarkRed = "#800000";
            DarkMagenta = "#800080";
            DarkYellow = "#808000";
            Gray = "#c0c0c0";
            DarkGray = "#808080";
            Blue = "#6666ff";
            Green = "#00ff00";
            Cyan = "#00ffff";
            Red = "#ff0000";
            Magenta = "#ff00ff";
            Yellow = "#ffff00";
            White = "#ffffff";
        }
    }

    public static string Black { get; }
    public static string DarkBlue { get; }
    public static string DarkGreen { get; }
    public static string DarkCyan { get; }
    public static string DarkRed { get; }
    public static string DarkMagenta { get; }
    public static string DarkYellow { get; }
    public static string Gray { get; }
    public static string DarkGray { get; }
    public static string Blue { get; }
    public static string Green { get; }
    public static string Cyan { get; }
    public static string Red { get; }
    public static string Magenta { get; }
    public static string Yellow { get; }
    public static string White { get; }
}