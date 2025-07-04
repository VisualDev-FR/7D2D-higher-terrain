# ⛰️ 7D2D - Higher Terrain

**Increase terrain depth in 7 Days to Die with one simple setting!**

This mod allows you to raise the base height of terrain during world generation, giving you **deeper underground space** and new vertical possibilities — all while staying within the game's 256-block height limit.

---

## 📦 Features

- Adds a new parameter to the RWG menu: `Terrain Offset`.
- Pushes terrain upward to allow for **much deeper underground areas**.
- Preserves full compatibility with vanilla world generation.
- Ideal for builders, miners, modders, and custom map creators.

## ⚙️ How It Works 📐

This mod doesn't modify the game's 256-block vertical limit.
Instead, it **shifts the entire terrain upwards** using the following logic:

```csharp
terrainHeight = TerrainOffset + (255f - TerrainOffset) * height / 255f;
```

* The Terrain Offset value raises the terrain baseline.
* The higher the offset, the deeper the underground becomes.
* However, surface terrain becomes flatter at higher offsets, as there’s less vertical space left for hills and mountains.

## 🧠 Usage Instructions

1. Launch 7 Days to Die and go to the RWG (Random World Generation) menu.
2. Set the new Terrain Offset parameter to your desired value (e.g., 20, 40...).
3. Generate your world as usual.
4. Load it up and enjoy a much deeper terrain!

## ⚠️ Disclaimer

Increasing the terrain offset can significantly increase memory usage and loading time.
High values may affect performance, especially on lower-end systems.
Recommended: Use moderate values (20–60) for stable gameplay.