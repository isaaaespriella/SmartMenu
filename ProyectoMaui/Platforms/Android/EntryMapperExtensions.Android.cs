#if ANDROID
using Microsoft.Maui.Handlers;
using Android.Widget;

namespace ProyectoMaui.Platforms.Android;

public static class EntryMapperExtensions
{
    public static void ConfigureEntryMapper()
    {
        EntryHandler.Mapper.ModifyMapping("Background", (handler, view, action) =>
        {
            action?.Invoke(handler, view);
            handler.PlatformView.Background = null;
        });
    }
}
#endif