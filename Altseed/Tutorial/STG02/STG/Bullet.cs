using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class Bullet : asd.TextureObject2D
    {
        public Bullet(asd.Vector2DF position,string bulletType)
        {
            // 画像を読み込み、弾のインスタンスに画像を設定する。
           Texture = asd.Engine.Graphics.CreateTexture2D(bulletType);

            // 弾のインスタンスに画像の中心位置を設定する。
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);

            // 弾のインスタンスの位置を設定する。
            Position = position;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            {
                Position = Position + new asd.Vector2DF(0, -2);
                //もし弾が画面上部に来たら、球を消す。
                if (Position.Y < -Texture.Size.Y / 2)
                {
                    Dispose();
                }

            }
        }
    }
}
