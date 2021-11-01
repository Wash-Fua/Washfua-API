using System;
using System.Collections.Generic;
using WashFua.Entities;

namespace WashFua.Repositories
{
    public interface IMamaFuaRepository
    {
        IEnumerable<MamaFua> GetMamaFuas();
        MamaFua GetMamaFua(Guid id);

        void CreateMamaFua(MamaFua mamaFua);

        void UpdateMamaFua(MamaFua mamaFua);

        void DeleteMamaFua(Guid id);
    }
}