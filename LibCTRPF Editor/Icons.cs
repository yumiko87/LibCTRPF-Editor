using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace libEditor
{
    public static class Icons
    {
        public static string[] GetIconsList()
        {
            string[] List = new string[]
            {
                "About15",
                "CapsLockOn15",
                "CapsLockOnFilled15",
                "CentreofGravity15",
                "UnCheckedCheckbox15",
                "CheckedCheckbox15",
                "ClearSymbol15",
                "ClearSymbolFilled15",
                "Clipboard25",
                "ClipboardFilled25",
                "CloseWindow20",
                "CloseWindowFilled20",
                "Controller15",
                "Cut25",
                "CutFilled25",
                "Duplicate25",
                "DuplicateFilled25",
                "Edit25",
                "EditFilled25",
                "EnterKey15",
                "EnterKeyFilled15",
                "FolderFilled15",
                "AddFavorite25",
                "AddFavoriteFilled25",
                "Star15",
                "File15",
                "GameController25",
                "GameControllerFilled25",
                "Grid15",
                "Info25",
                "InfoFilled25",
                "UserManualFilled15",
                "HandCursor15",
                "Happy15",
                "HappyFilled15",
                "Keyboard25",
                "KeyboardFilled25",
                "More15",
                "Plus25",
                "PlusFilled25",
                "RAM15",
                "Restart15",
                "Rocket40",
                "Save25",
                "Search15",
                "Settings15",
                "Shutdown15",
                "Maintenance15",
                "Trash25",
                "TrashFilled25",
                "Unsplash15"
            };
            
            return List;
        }
        
        public static int GetIconOffset(string Name)
        {
            Dictionary<string, int> IconsOffset = new Dictionary<string, int>()
            {
                {"About15", 0x58164},
                {"CapsLockOn15", 0x55BCC},
                {"CapsLockOnFilled15", 0x55358},
                {"CentreofGravity15", 0x54AEC},
                {"UnCheckedCheckbox15", 0x33AC4},
                {"CheckedCheckbox15", 0x5428C},
                {"ClearSymbol15", 0x53A3C},
                {"ClearSymbolFilled15", 0x531C0},
                {"Clipboard25", 0x5233C},
                {"ClipboardFilled25", 0x51490},
                {"CloseWindow20", 0x50984},
                {"CloseWindowFilled20", 0x4FE4C},
                {"Controller15", 0x4F600},
                {"Cut25", 0x4E7A8},
                {"CutFilled25", 0x4D924},
                {"Duplicate25", 0x4B820},
                {"DuplicateFilled25", 0x4A974},
                {"Edit25", 0x49B14},
                {"EditFilled25", 0x48C88},
                {"EnterKey15", 0x4844C},
                {"EnterKeyFilled15", 0x47BE4},
                {"FolderFilled15", 0x46B78},
                {"AddFavorite25", 0x572D4},
                {"AddFavoriteFilled25", 0x56418},
                {"Star15", 0x36028},
                {"File15", 0x473C4},
                {"GameController25", 0x45468},
                {"GameControllerFilled25", 0x44598},
                {"Grid15", 0x43D78},
                {"Info25", 0x41654},
                {"InfoFilled25", 0x407C8},
                {"UserManualFilled15", 0x32A14},
                {"HandCursor15", 0x4352C},
                {"Happy15", 0x42D04},
                {"HappyFilled15", 0x424B4},
                {"Keyboard25", 0x3F94C},
                {"KeyboardFilled25", 0x3EAA4},
                {"More15", 0x3DA34},
                {"Plus25", 0x3CBD4},
                {"PlusFilled25", 0x3BD48},
                {"RAM15", 0x3B530},
                {"Restart15", 0x36848},
                {"Rocket40", 0x38F50},
                {"Save25", 0x380F0},
                {"Search15", 0x378C0},
                {"Settings15", 0x37084},
                {"Shutdown15", 0x36848},
                {"Maintenance15", 0x3E254},
                {"Trash25", 0x351C0},
                {"TrashFilled25", 0x34330},
                {"Unsplash15", 0x33288}
            };
            
            return IconsOffset[Name];
        }
        
        public static int GetIconsAmount()
        {
            return Icons.GetIconsList().Length;
        }
        
        public static int GetDimension(string Dimension, string Name)
        {
            int Result = -1;
            
            foreach (string i in Icons.GetIconsList())
            {
                if (Dimension == "Width" || Dimension == "Height")
                {
                    if (i == Name)
                    {
                        if (Name.Contains("15"))
                            Result = 15;
                        
                        else if (Name.Contains("20"))
                            Result = 20;
                        
                        else if (Name.Contains("25"))
                            Result = 25;
                        
                        else if (Name.Contains("40"))
                            Result = 40;
                        
                        break;
                    }
                }
            }
            
            return Result;
        }
        
        public static int GetLength(string Name)
        {
            int Result = -1;
            
            foreach (string i in Icons.GetIconsList())
            {
                if (i == Name)
                {
                    if (Name.Contains("15"))
                        Result = (15 * 15 * 4);
                    
                    else if (Name.Contains("20"))
                        Result = (20 * 20 * 4);
                    
                    else if (Name.Contains("25"))
                        Result = (25 * 25 * 4);
                    
                    else if (Name.Contains("40"))
                        Result = (40 * 40 * 4);
                    
                    break;
                }
            }
            
            return Result;
        }
        
        public static byte[] GetBytes(byte[] LibBytes, string Name)
        {
            return LibBytes.Skip(Icons.GetIconOffset(Name)).Take(Icons.GetLength(Name)).ToArray();
        }
    }
}