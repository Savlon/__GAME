using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile 
{
	private byte _id;
	private Vector3 _position;
	private bool _passable;
	private bool _isBaseTile;
	private Sprite _image;

	//TILES NEW
	private Sprite[] _tileset;
	private int[] _spriteIndexValues;
	private Dictionary <int, Sprite> _tilesetSprites;

	public Tile (int id, Vector3 position = new Vector3 (), bool passable = true, bool isBaseTile = true)
	{
		_id = (byte)id;
		_position = position;
		_passable = passable;
		_isBaseTile = isBaseTile;

		SetupTileReferences ();

		if (TileDatabase.tiles [id] != null)
			Debug.LogError ("Tile Database already contains ID: " + id);

		TileDatabase.tiles [id] = this;

		_tileset = new Sprite[47];
		_tileset = TileDatabase.GetTilesetSprites (id);
		_tilesetSprites = new Dictionary<int, Sprite> ();

		Image = _tileset[0];

		for (int i = 0; i < _tileset.Length; i++) 
		{
			_tilesetSprites.Add (i, _tileset[i]);
		}

	}

	public Tile (Tile tileClone, Vector3 position)
	{
		_id = tileClone._id;
		_position = position;
		_passable = tileClone._passable;
		_isBaseTile = tileClone._isBaseTile;
		_image = tileClone._image;
	}

	public virtual void AdjustHealth (Level level, int x, int y, Mob source, int amount, Direction direction)
	{	}

	public virtual void Collide (Level level, int x, int y, Entity source)
	{	}

	public virtual void StepOn (Level level, int x, int y, Entity source)
	{ 
		source.GetComponent <Animator> ().SetBool ("Swim", false);
		source.Speed = source.NormalSpeed;
	}

	public virtual bool Interact (Level Level, int x, int y, Player player, Item item)
	{ return false; }

	public virtual void Update (Level level, int x , int y)
	{	}
	
	public virtual void UpdateImage (Level level, int x, int y)
	{
//		bool check = level.GetTileOnLayer ((float)x, (float)y, _isBaseTile ? 0 : 1).ID != ID;
		bool up = level.GetTileOnLayer ((float)x, (float)y + 1, _isBaseTile ? 0 : 1).ID != ID;
		bool down = level.GetTileOnLayer ((float)x, (float)y - 1, _isBaseTile ? 0 : 1).ID != ID;
		bool left = level.GetTileOnLayer ((float)x - 1, (float)y, _isBaseTile ? 0 : 1).ID != ID;
		bool right = level.GetTileOnLayer ((float)x + 1, (float)y, _isBaseTile ? 0 : 1).ID != ID;
		
		bool upLeft = level.GetTileOnLayer ((float)x - 1, (float)y + 1, _isBaseTile ? 0 : 1).ID != ID;
		bool upRight = level.GetTileOnLayer ((float)x + 1, (float)y + 1, _isBaseTile ? 0 : 1).ID != ID;
		bool downLeft = level.GetTileOnLayer ((float)x - 1, (float)y - 1, _isBaseTile ? 0 : 1).ID != ID;
		bool downRight = level.GetTileOnLayer ((float)x + 1, (float)y - 1, _isBaseTile ? 0 : 1).ID != ID;

//		bool up = level.GetTile ((float)x, (float)y + 1).ID != ID;
//		bool down = level.GetTile ((float)x, (float)y - 1).ID != ID;
//		bool left = level.GetTile ((float)x - 1, (float)y).ID != ID;
//		bool right = level.GetTile ((float)x + 1, (float)y).ID != ID;
//		
//		bool upLeft = level.GetTile ((float)x - 1, (float)y + 1).ID != ID;
//		bool upRight = level.GetTile ((float)x + 1, (float)y + 1).ID != ID;
//		bool downLeft = level.GetTile ((float)x - 1, (float)y - 1).ID != ID;
//		bool downRight = level.GetTile ((float)x + 1, (float)y - 1).ID != ID;
		
		int index = 0;
		int n = !up ? 1 : 0;
		int ne = !upRight ? 2 : 0;
		int e = !right ? 4 : 0;
		int se = !downRight ? 8 : 0;
		int s = !down ? 16 : 0;
		int sw = !downLeft ? 32 : 0;
		int w = !left ? 64 : 0;
		int nw = !upLeft ? 128 : 0;

		index = n + ne + e + se + s + sw + w + nw;


		_image = _tilesetSprites[_spriteIndexValues[index]];

		level.SetTileOnLayer ((float)x, (float)y, this, level.GetData ((float)x, (float)y), _isBaseTile ? 0 : 1);
//		level.SetTile ((float)x, (float)y, this, level.GetData ((float)x, (float)y));
	}

	public byte ID
	{
		get {return _id;}
		set {_id = value;}
	}

	public Vector3 Position
	{
		get {return _position;}
		set {_position = value;}
	}

	public bool Passable
	{
		get {return _passable;}
		set {_passable = value;}
	}

	public bool IsBaseTile
	{
		get {return _isBaseTile;}
		private set {_isBaseTile = value;}
	}

	public Sprite Image
	{
		get {return _image;}
		set {_image = value;}
	}

	public override bool Equals (object obj)
	{
		if (obj == null)
			return false;

		Tile tile = (Tile)obj;

		return (_id == tile.ID) && (Position == tile.Position);
	}

	public override int GetHashCode ()
	{
		return _id.GetHashCode () ^ Position.GetHashCode ();
	}

	public override string ToString ()
	{
		return string.Format ("[Tile: ID={0}, Position={1}, Passable={2}, IsBaseTile={3}, Image={4}]", ID, Position, Passable, IsBaseTile, Image);
	}

	private void SetupTileReferences ()
	{
		_spriteIndexValues = new int[256];
		
		_spriteIndexValues[0] = 0;
		_spriteIndexValues[1] = 1;
		_spriteIndexValues[2] = 0;
		_spriteIndexValues[3] = 1;
		_spriteIndexValues[4] = 2;
		_spriteIndexValues[5] = 3;
		_spriteIndexValues[6] = 2;
		_spriteIndexValues[7] = 4;
		_spriteIndexValues[8] = 0;
		_spriteIndexValues[9] = 1;
		
		_spriteIndexValues[10] = 0;
		_spriteIndexValues[11] = 1;
		_spriteIndexValues[12] = 2;
		_spriteIndexValues[13] = 3;
		_spriteIndexValues[14] = 2;
		_spriteIndexValues[15] = 4;
		_spriteIndexValues[16] = 5;
		_spriteIndexValues[17] = 6;
		_spriteIndexValues[18] = 5;
		_spriteIndexValues[19] = 6;
		
		_spriteIndexValues[20] = 7;
		_spriteIndexValues[21] = 8;
		_spriteIndexValues[22] = 7;
		_spriteIndexValues[23] = 9;
		_spriteIndexValues[24] = 5;
		_spriteIndexValues[25] = 6;
		_spriteIndexValues[26] = 5;
		_spriteIndexValues[27] = 6;
		_spriteIndexValues[28] = 10;
		_spriteIndexValues[29] = 11;
		
		_spriteIndexValues[30] = 10;
		_spriteIndexValues[31] = 12;
		_spriteIndexValues[32] = 0;
		_spriteIndexValues[33] = 1;
		_spriteIndexValues[34] = 0;
		_spriteIndexValues[35] = 1;
		_spriteIndexValues[36] = 2;
		_spriteIndexValues[37] = 3;
		_spriteIndexValues[38] = 2;
		_spriteIndexValues[39] = 4;
		
		_spriteIndexValues[40] = 0;
		_spriteIndexValues[41] = 1;
		_spriteIndexValues[42] = 0;
		_spriteIndexValues[43] = 1;
		_spriteIndexValues[44] = 2;
		_spriteIndexValues[45] = 3;
		_spriteIndexValues[46] = 2;
		_spriteIndexValues[47] = 4;
		_spriteIndexValues[48] = 5;
		_spriteIndexValues[49] = 6;
		
		_spriteIndexValues[50] = 5;
		_spriteIndexValues[51] = 6;
		_spriteIndexValues[52] = 7;
		_spriteIndexValues[53] = 8;
		_spriteIndexValues[54] = 7;
		_spriteIndexValues[55] = 9;
		_spriteIndexValues[56] = 5;
		_spriteIndexValues[57] = 6;
		_spriteIndexValues[58] = 5;
		_spriteIndexValues[59] = 6;
		
		_spriteIndexValues[60] = 10;
		_spriteIndexValues[61] = 11;
		_spriteIndexValues[62] = 10;
		_spriteIndexValues[63] = 12;
		_spriteIndexValues[64] = 13;
		_spriteIndexValues[65] = 14;
		_spriteIndexValues[66] = 13;
		_spriteIndexValues[67] = 14;
		_spriteIndexValues[68] = 15;
		_spriteIndexValues[69] = 16;
		
		_spriteIndexValues[70] = 15;
		_spriteIndexValues[71] = 17;
		_spriteIndexValues[72] = 13;
		_spriteIndexValues[73] = 14;
		_spriteIndexValues[74] = 13;
		_spriteIndexValues[75] = 14;
		_spriteIndexValues[76] = 15;
		_spriteIndexValues[77] = 16;
		_spriteIndexValues[78] = 15;
		_spriteIndexValues[79] = 17;
		
		_spriteIndexValues[80] = 18;
		_spriteIndexValues[81] = 19;
		_spriteIndexValues[82] = 18;
		_spriteIndexValues[83] = 19;
		_spriteIndexValues[84] = 20;
		_spriteIndexValues[85] = 21;
		_spriteIndexValues[86] = 20;
		_spriteIndexValues[87] = 22;
		_spriteIndexValues[88] = 18;
		_spriteIndexValues[89] = 19;
		
		_spriteIndexValues[90] = 18;
		_spriteIndexValues[91] = 19;
		_spriteIndexValues[92] = 23;
		_spriteIndexValues[93] = 24;
		_spriteIndexValues[94] = 23;
		_spriteIndexValues[95] = 25;
		_spriteIndexValues[96] = 13;
		_spriteIndexValues[97] = 14;
		_spriteIndexValues[98] = 13;
		_spriteIndexValues[99] = 14;
		
		_spriteIndexValues[100] = 15;
		_spriteIndexValues[101] = 16;
		_spriteIndexValues[102] = 15;
		_spriteIndexValues[103] = 17;
		_spriteIndexValues[104] = 13;
		_spriteIndexValues[105] = 14;
		_spriteIndexValues[106] = 13;
		_spriteIndexValues[107] = 14;
		_spriteIndexValues[108] = 15;
		_spriteIndexValues[109] = 16;
		
		_spriteIndexValues[110] = 15;
		_spriteIndexValues[111] = 17;
		_spriteIndexValues[112] = 26;
		_spriteIndexValues[113] = 27;
		_spriteIndexValues[114] = 26;
		_spriteIndexValues[115] = 27;
		_spriteIndexValues[116] = 28;
		_spriteIndexValues[117] = 29;
		_spriteIndexValues[118] = 28;
		_spriteIndexValues[119] = 30;
		
		_spriteIndexValues[120] = 26;
		_spriteIndexValues[121] = 27;
		_spriteIndexValues[122] = 26;
		_spriteIndexValues[123] = 27;
		_spriteIndexValues[124] = 31;
		_spriteIndexValues[125] = 32;
		_spriteIndexValues[126] = 31;
		_spriteIndexValues[127] = 33;
		_spriteIndexValues[128] = 0;
		_spriteIndexValues[129] = 1;
		
		_spriteIndexValues[130] = 0;
		_spriteIndexValues[131] = 1;
		_spriteIndexValues[132] = 2;
		_spriteIndexValues[133] = 3;
		_spriteIndexValues[134] = 2;
		_spriteIndexValues[135] = 4;
		_spriteIndexValues[136] = 0;
		_spriteIndexValues[137] = 1;
		_spriteIndexValues[138] = 0;
		_spriteIndexValues[139] = 1;
		
		_spriteIndexValues[140] = 2;
		_spriteIndexValues[141] = 3;
		_spriteIndexValues[142] = 2;
		_spriteIndexValues[143] = 4;
		_spriteIndexValues[144] = 5;
		_spriteIndexValues[145] = 6;
		_spriteIndexValues[146] = 5;
		_spriteIndexValues[147] = 6;
		_spriteIndexValues[148] = 7;
		_spriteIndexValues[149] = 8;
		
		_spriteIndexValues[150] = 7;
		_spriteIndexValues[151] = 9;
		_spriteIndexValues[152] = 5;
		_spriteIndexValues[153] = 6;
		_spriteIndexValues[154] = 5;
		_spriteIndexValues[155] = 6;
		_spriteIndexValues[156] = 10;
		_spriteIndexValues[157] = 11;
		_spriteIndexValues[158] = 10;
		_spriteIndexValues[159] = 12;
		
		_spriteIndexValues[160] = 0;
		_spriteIndexValues[161] = 1;
		_spriteIndexValues[162] = 0;
		_spriteIndexValues[163] = 1;
		_spriteIndexValues[164] = 2;
		_spriteIndexValues[165] = 3;
		_spriteIndexValues[166] = 2;
		_spriteIndexValues[167] = 4;
		_spriteIndexValues[168] = 0;
		_spriteIndexValues[169] = 1;
		
		_spriteIndexValues[170] = 0;
		_spriteIndexValues[171] = 1;
		_spriteIndexValues[172] = 2;
		_spriteIndexValues[173] = 3;
		_spriteIndexValues[174] = 2;
		_spriteIndexValues[175] = 4;
		_spriteIndexValues[176] = 5;
		_spriteIndexValues[177] = 6;
		_spriteIndexValues[178] = 5;
		_spriteIndexValues[179] = 6;
		
		_spriteIndexValues[180] = 7;
		_spriteIndexValues[181] = 8;
		_spriteIndexValues[182] = 7;
		_spriteIndexValues[183] = 9;
		_spriteIndexValues[184] = 5;
		_spriteIndexValues[185] = 6;
		_spriteIndexValues[186] = 5;
		_spriteIndexValues[187] = 6;
		_spriteIndexValues[188] = 10;
		_spriteIndexValues[189] = 11;
		
		_spriteIndexValues[190] = 10;
		_spriteIndexValues[191] = 12;
		_spriteIndexValues[192] = 13;
		_spriteIndexValues[193] = 34;
		_spriteIndexValues[194] = 13;
		_spriteIndexValues[195] = 34;
		_spriteIndexValues[196] = 15;
		_spriteIndexValues[197] = 35;
		_spriteIndexValues[198] = 15;
		_spriteIndexValues[199] = 36;
		
		_spriteIndexValues[200] = 13;
		_spriteIndexValues[201] = 34;
		_spriteIndexValues[202] = 13;
		_spriteIndexValues[203] = 34;
		_spriteIndexValues[204] = 15;
		_spriteIndexValues[205] = 35;
		_spriteIndexValues[206] = 15;
		_spriteIndexValues[207] = 36;
		_spriteIndexValues[208] = 18;
		_spriteIndexValues[209] = 37;
		
		_spriteIndexValues[210] = 18;
		_spriteIndexValues[211] = 37;
		_spriteIndexValues[212] = 20;
		_spriteIndexValues[213] = 38;
		_spriteIndexValues[214] = 20;
		_spriteIndexValues[215] = 39;
		_spriteIndexValues[216] = 18;
		_spriteIndexValues[217] = 37;
		_spriteIndexValues[218] = 18;
		_spriteIndexValues[219] = 37;
		
		_spriteIndexValues[220] = 23;
		_spriteIndexValues[221] = 40;
		_spriteIndexValues[222] = 23;
		_spriteIndexValues[223] = 41;
		_spriteIndexValues[224] = 13;
		_spriteIndexValues[225] = 34;
		_spriteIndexValues[226] = 13;
		_spriteIndexValues[227] = 34;
		_spriteIndexValues[228] = 15;
		_spriteIndexValues[229] = 35;
		
		_spriteIndexValues[230] = 15;
		_spriteIndexValues[231] = 36;
		_spriteIndexValues[232] = 13;
		_spriteIndexValues[233] = 34;
		_spriteIndexValues[234] = 13;
		_spriteIndexValues[235] = 34;
		_spriteIndexValues[236] = 15;
		_spriteIndexValues[237] = 35;
		_spriteIndexValues[238] = 15;
		_spriteIndexValues[239] = 36;
		
		_spriteIndexValues[240] = 26;
		_spriteIndexValues[241] = 42;
		_spriteIndexValues[242] = 26;
		_spriteIndexValues[243] = 42;
		_spriteIndexValues[244] = 28;
		_spriteIndexValues[245] = 43;
		_spriteIndexValues[246] = 28;
		_spriteIndexValues[247] = 44;
		_spriteIndexValues[248] = 26;
		_spriteIndexValues[249] = 42;
		
		_spriteIndexValues[250] = 26;
		_spriteIndexValues[251] = 42;
		_spriteIndexValues[252] = 31;
		_spriteIndexValues[253] = 45;
		_spriteIndexValues[254] = 31;
		_spriteIndexValues[255] = 46;
	}
	

}
