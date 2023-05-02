using CapaLogicaNegocio.Adds;
using CapaLogicaNegocio.Deletes;
using CapaLogicaNegocio.Lists;
using CapaLogicaNegocio.RecoverData;
using CapaLogicaNegocio.Tables;
using CapaLogicaNegocio.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.ObjectPooling
{
    public class Pool
    {
        private Stack<BrancheAdd> _poolBrancheAdd = new Stack<BrancheAdd>();
        private Stack<BrancheList> _poolBrancheList = new Stack<BrancheList>();
        private Stack<BrancheDelete> _poolBrancheDelete = new Stack<BrancheDelete>();
        private Stack<BrancheRData> _poolBrancheRData = new Stack<BrancheRData>();
        private Stack<BrancheUpdate> _poolBrancheUpdate = new Stack<BrancheUpdate>();
        private Stack<ImageList> _poolImageList = new Stack<ImageList>();
        private Stack<Delete> _poolDelete = new Stack<Delete>();
        private Stack<Random> _poolRandom = new Stack<Random>();
        private Stack<DayList> _poolDayList = new Stack<DayList>();
        private Stack<BranchesTable> _poolBranchesTable = new Stack<BranchesTable>();
        private Stack<SchedulesTable> _poolSchedulesTable = new Stack<SchedulesTable>();
        private Stack<ProductTable> _poolProductTable = new Stack<ProductTable>();
        public object GetInstance(object obj)
        {
            switch (obj)
            { 
                case BrancheAdd brancheAdd:
                    return _poolBrancheAdd.Count > 0 ? _poolBrancheAdd.Pop() : obj;
                case BrancheList brancheList:
                    return _poolBrancheList.Count > 0 ? _poolBrancheList.Pop() : obj;
                case BrancheDelete brancheDelete:
                    return _poolBrancheDelete.Count > 0 ? _poolBrancheDelete.Pop() : obj;
                case BrancheRData brancheRData:
                    return _poolBrancheRData.Count > 0 ? _poolBrancheRData.Pop() : obj;
                case BrancheUpdate brancheUpdate:
                    return _poolBrancheUpdate.Count > 0 ? _poolBrancheUpdate.Pop() : obj;
                case ImageList imageList:
                    return _poolImageList.Count > 0 ? _poolImageList.Pop() : obj;
                case Delete delete:
                    return _poolDelete.Count > 0 ? _poolDelete.Pop() : obj;
                case Random random:
                    return _poolRandom.Count > 0 ? _poolRandom.Pop() : obj;
                case DayList dayList:
                    return _poolDayList.Count > 0 ? _poolDayList.Pop() : obj;
                case BranchesTable branchesTable:
                    return _poolBranchesTable.Count > 0 ? _poolBranchesTable.Pop() : obj;
                case SchedulesTable schedulesTable:
                    return _poolSchedulesTable.Count > 0 ? _poolSchedulesTable.Pop() : obj;
                case ProductTable productTable:
                    return _poolProductTable.Count > 0 ? _poolProductTable.Pop() : obj;
                default: return obj;


            }
        }

        public void ReleaseInstance(BrancheAdd instance)
        {
            _poolBrancheAdd.Push(instance);
        }

        public void ReleaseInstance(BrancheList instance)
        {
            _poolBrancheList.Push(instance);
        }

        public void ReleaseInstance(BrancheDelete instance)
        {
            _poolBrancheDelete.Push(instance);
        }

        public void ReleaseInstance(BrancheRData instance)
        {
            _poolBrancheRData.Push(instance);
        }

        public void ReleaseInstance(BrancheUpdate instance)
        {
            _poolBrancheUpdate.Push(instance);
        }


        public void ReleaseInstance(ImageList instance)
        {
            _poolImageList.Push(instance);
        }

        public void ReleaseInstance(Delete instance)
        {
            _poolDelete.Push(instance);
        }

        public void ReleaseInstance(Random instance)
        {
            _poolRandom.Push(instance);

        }
        public void ReleaseInstance(DayList instance)
        {
            _poolDayList.Push(instance);

        }
        public void ReleaseInstance(BranchesTable instance)
        {
            _poolBranchesTable.Push(instance);
        }
        public void ReleaseInstance(SchedulesTable instance)
        {
            _poolSchedulesTable.Push(instance);

        }
        public void ReleaseInstance(ProductTable instance)
        {
            _poolProductTable.Push(instance);
        }
    }
}
