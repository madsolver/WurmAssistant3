﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AldurSoft.WurmApi.Tests.Builders.WurmClient {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Defaults {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Defaults() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AldurSoft.WurmApi.Tests.Builders.WurmClient.Defaults", typeof(Defaults).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to // In this file you can put console commands that you want to execute on startup.
        ///// This file is handled AFTER keybindings.txt, so a keybind here will override it.
        ///
        ///// This file will be automatically created with default values if it is missing.
        ///// So if you ever manage to mess up this file, just delete it to get a clean one.
        ///say /uptime
        ///say /time
        ///.
        /// </summary>
        internal static string autorun {
            get {
                return ResourceManager.GetString("autorun", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #Wurm Online client properties
        ///#Sun Jul 26 00:39:19 CEST 2015
        ///show_body_in_inventory=true
        ///enable_contribution_culling=true
        ///sound_cache_enabled=true
        ///viewport_bob=true
        ///use_smooth_points=false
        ///hide_menu_examine=false
        ///color_white=1.0,1.0,1.0
        ///mark_text_read=true
        ///no_terrain_render=false
        ///pbuffer_enabled=false
        ///has_read_eula=true
        ///color_error=1.0,0.3,0.3
        ///use_color_picking=true
        ///render_glow=true
        ///trees=4
        ///vbo_enabled=2
        ///reflections=4
        ///animation_playback_self=0
        ///showKChat=true
        ///debug_mode=false
        ///color_tea [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string gamesettings {
            get {
                return ResourceManager.GetString("gamesettings", resourceCulture);
            }
        }
    }
}