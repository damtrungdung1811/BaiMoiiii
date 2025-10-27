using BaiMoiiii.DAL;
using BaiMoiiii.MODEL;

namespace BaiMoiiii.BUS
{
    public class BaoHanhBUS
    {
        private readonly BaoHanhDAL _dal;

        // ✅ constructor mới nhận connectionString thay vì IConfiguration
        public BaoHanhBUS(string connectionString)
        {
            _dal = new BaoHanhDAL(connectionString);
        }

        // ==================== CRUD ====================
        public List<BaoHanh> GetAll() => _dal.GetAll();

        public BaoHanh? GetById(int id) => _dal.GetById(id);

        public bool Add(BaoHanh bh)
        {
            if (string.IsNullOrWhiteSpace(bh.NhaCungCap))
                throw new ArgumentException("Nhà cung cấp không được để trống!");
            return _dal.Create(bh);
        }

        public bool Update(BaoHanh bh)
        {
            if (bh.MaBaoHanh <= 0)
                throw new ArgumentException("Mã bảo hành không hợp lệ!");
            return _dal.Update(bh);
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Mã bảo hành không hợp lệ!");
            return _dal.Delete(id);
        }
    }
}
