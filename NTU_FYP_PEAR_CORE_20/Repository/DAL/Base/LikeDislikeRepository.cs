using Microsoft.EntityFrameworkCore;
using NTU_FYP_PEAR_CORE_20.Data;
using NTU_FYP_PEAR_CORE_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTU_FYP_PEAR_CORE_20.Repository.Base
{
    // Querying Data: https://www.learnentityframeworkcore.com/dbset/querying-data
    public class LikeDislikeRepository : BaseRepository<LikeDislike>
    {
        public LikeDislikeRepository(ApplicationDbContext context) : base(context) { }

        public LikeDislike Create(int patientAllocationID, int likeDislikeListID, bool isLike)
        {
            LikeDislike entity = new LikeDislike();
            entity.patientAllocationID = patientAllocationID;
            entity.likeDislikeListID = likeDislikeListID;
            entity.isLike = isLike;
            return entity;
        }
        public LikeDislike CreateAdd(int patientAllocationID, int likeDislikeListID, bool isLike)
        {
            LikeDislike entity = Create(patientAllocationID, likeDislikeListID, isLike);
            Add(entity);
            return entity;
        }
        public List<LikeDislike> GetAllPatientLD(int patientAID)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isDeleted != true).Include(i => i.List_LikeDislike).ToList();
        }
        public List<LikeDislike> GetPatientLD(int patientAID, bool isLike)
        {
            return GetAll().Where(i => i.patientAllocationID == patientAID && i.isLike == isLike && i.isDeleted != true).Include(i => i.List_LikeDislike).ToList();
        }
        public LikeDislike GetOnePatientLD(int patientAID, int listID)
        {
            return GetAll().Include(i => i.List_LikeDislike).FirstOrDefault(i => i.patientAllocationID == patientAID && i.likeDislikeListID == listID && i.isDeleted != true);
        }

    }
}