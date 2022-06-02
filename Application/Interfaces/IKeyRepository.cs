using Application.ResponseDTO.Key;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IKeyRepository
    {
        public void CreateKey(KeyEntity key);
        public void UpdateKey(KeyEntity key);
        public void DeleteKey(KeyEntity key);
        public Task<IEnumerable<KeyResponseDTO>> FindKeysByNameAsync(int offset, int limit, string name);
        public Task<IEnumerable<KeyResponseDTO>> GetKeysAsync(int offset, int limit, Guid? auditoryTypeId);
        public Task<IEnumerable<KeyResponseDTO>> GetKeysFreeOnlyAsync(int offset, int limit, Guid? auditoryTypeId);
        public Task<IEnumerable<KeyPermissionResponseDTO>> FindKeyPermissionsByNameAsync(Guid empId, int offset, int limit, string name);
        public Task<IEnumerable<KeyPermissionResponseDTO>> GetKeyPermissionsAsync(Guid empId, int offset, int limit, Guid? auditoryTypeId);
        public Task<IEnumerable<KeyPermissionResponseDTO>> GetKeyPermissionsFreeOnlyAsync(Guid empId, int offset, int limit, Guid? auditoryTypeId);
        public Task<KeyDetailsResponseDTO?> GetKeyDetailsOrNullAsync(Guid id);
        public Task<bool> CheckKeyExistenceByIdAsync(Guid id);
        public Task<bool> CheckKeyUniqueNameAsync(string name, Guid? exceptiveKeyId = null);
    }
}
