using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items.ItemSprites;
using Poggus.Player;

namespace Poggus.Items
{
    public abstract class AbstractItem : IItem
    {
        public bool interactable { get; set; } = true;
        public bool spawnOnRoomClear;
        protected ISprite sprite;
        protected Rectangle rect;

        Rectangle IItem.rect { get => this.rect; set => this.rect = value; }
        public ItemEnum itemType {get; set;}
        public AbstractItem(ItemEnum itemType, Point pos, Point size)
        {
            this.itemType = itemType;
            this.rect = new Rectangle(pos, size);
        }
        public virtual void CreateSprite()
        {
            this.sprite = ItemSpriteFactory.Instance.GetItemSprite(itemType);
            this.rect.Width = (int)(sprite.SourceRect[0].Width * Game1.gameScaleX);
            this.rect.Height = (int)(sprite.SourceRect[0].Height * Game1.gameScaleY);
        }
        public virtual void Update(GameTime gameTime)
        {
            if (spawnOnRoomClear)
            {
                if(Game1.instance.GetDungeon().GetCurrentLevel().GetEnemyList().Count == 0)
                {
                    interactable = true;
                    this.sprite.Update(gameTime);
                }
                else
                {
                    interactable = false;
                }
            }
            else
            {
                interactable = true;
                this.sprite.Update(gameTime);
            }
        }
        public virtual void Draw(SpriteBatch batch)
        {
            if (spawnOnRoomClear)
            {
                if (Game1.instance.GetDungeon().GetCurrentLevel().GetEnemyList().Count == 0)
                {
                    this.sprite.Draw(batch, this.rect);
                }
            }
            else
            {
                this.sprite.Draw(batch, this.rect);
            }
        }
        public virtual void SetRectangle(Rectangle rect)
        {
            this.rect = rect;
        }
        public virtual Rectangle GetRectangle()
        {
            return this.rect;
        }
        public Point GetPosition()
        {
            return this.rect.Location;
        }
        public void SetPosition(Point pos)
        {
            this.rect = new Rectangle(pos, rect.Size);
        }
        
    }
}
