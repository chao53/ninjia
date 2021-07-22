using System.IO;
using System.Text;
using UnityEngine;
using XLua;


/// <summary>
/// 热更新测试脚本——该脚本新建一个 Lua环境，并完成对 Lua脚本的指向调用
/// </summary>
public class ChinarHotFix : MonoBehaviour
{
    private LuaEnv luaEnv; //声明一个Lua环境对象


    void Start()
    {
        luaEnv = new LuaEnv();                     //实例化一个
        luaEnv.AddLoader(MyLoader);            //添加Loader
        luaEnv.DoString("require'hotfix'"); //引用名为： ChinarLuaTest 的 Lua 脚本
    }


    /// <summary>
    /// 自定义一个 Loader 
    /// </summary>
    /// <param name="luaFileName">Lua文件名</param>
    /// <returns>字节组</returns>
    private byte[] MyLoader(ref string luaFileName)
    {
        string adsPath = Application.streamingAssetsPath + "/" + luaFileName + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(adsPath));
    }


        /// <summary>
        /// 释放掉函数
        /// 此函数会在 OnDestroy 之前调用
        /// </summary>
        private void OnDisable()
    {
        luaEnv.DoString("require'Dispose'");
    }

    /// <summary>
    /// 释放资源
    /// 此函数会在最后调用，物体被删除时
    /// </summary>
    private void OnDestroy()
    {
        luaEnv.Dispose();
    }
}
