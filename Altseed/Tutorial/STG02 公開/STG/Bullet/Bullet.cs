using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class Bullet : CollidableObject
    {
        public Bullet(asd.Vector2DF position, string bulletType)
        {
            // 画像を読み込み、弾のインスタンスに画像を設定する。
            Texture = asd.Engine.Graphics.CreateTexture2D(bulletType);

            // 弾のインスタンスに画像の中心位置を設定する。
            CenterPosition = new asd.Vector2DF(Texture.Size.X / 2.0f, Texture.Size.Y / 2.0f);

            // 弾のインスタンスの位置を設定する。
            Position = position;

            // 画像の半分の大きさを Radius とする
            Radius = Texture.Size.X / 2.0f;
            
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

        // 衝突時の動作
        public override void OnCollide(CollidableObject obj)
        {
            // ゲームからオブジェクトを消滅させる
            Dispose();
        }

        // 自機の弾との当たり判定をコントロールするメソッド
        protected void CollideWith(CollidableObject obj)
        {
            // 当たり判定の相手が見つかってない場合はメソッドを終了
            if (obj == null)
                return;

            // obj が Bulletである場合にのみelse内を動作させる
            if (obj is Bullet)
            {
                // obj が bullet であることを明示
                CollidableObject bullet = obj;

                // bulletと衝突した場合には、衝突時処理を行う
                if (IsCollide(bullet))
                {
                    OnCollide(bullet);
                    bullet.OnCollide(this);
                }
            }
        }

    }
}
