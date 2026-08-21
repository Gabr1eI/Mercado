namespace Mercado.Common.Base;

public abstract class Entity {

    public Guid id { get; protected set; }

    public Entity() {
        this.id = Guid.NewGuid();
    }

    public override bool Equals(object? obj) {
        if (obj == null || obj.GetType() != this.GetType()) {
            return false;
        }

        Entity other = (Entity)obj;
        return other.id == this.id;
    }

    public static bool operator ==(Entity left, Entity right) {
        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right) {
        return !(left == right);
    }
}
