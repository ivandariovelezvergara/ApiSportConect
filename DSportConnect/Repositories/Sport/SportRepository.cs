using DSportConnect.Models.Sport;
using Entity.Enumerable;
using Entity.Service.Sport;
using MongoDB.Driver;

namespace DSportConnect.Repositories.Sport
{
    public class SportRepository : ISportRepository
    {
        private readonly IMongoCollection<SportInformation> _sportCollection;

        public SportRepository(IMongoClient mongoClient, string databaseName)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _sportCollection = database.GetCollection<SportInformation>("Sport");
        }

        #region GetAllSportsAsync
        public async Task<List<SportResponse>> GetAllSportsAsync()
        {
            List<SportResponse> sportResponse = new List<SportResponse>();
            List<SportInformation> list = await _sportCollection.Find(_ => true).ToListAsync();
            if (list.Count < 1)
                return sportResponse;
            foreach (SportInformation _sport in list)
            {
                SportResponse sportGet = new SportResponse
                {
                    Id = _sport.Id,
                    Name = _sport.Name,
                    Description = _sport.Description,
                    Status = _sport.Status,
                    SelfEvaluation = new List<EvaluationResponse>(),
                    ThirdPartyEvaluation = new List<EvaluationResponse>(),
                    RefereeSelfEvaluation = new List<EvaluationResponse>(),
                    RefereeThirdPartyEvaluation = new List<EvaluationResponse>(),
                    SpecialPlayerSelfEvaluation = new List<EvaluationResponse>(),
                    SpecialPlayerThirdPartyEvaluation = new List<EvaluationResponse>(),
                    CoachSelfEvaluation = new List<EvaluationResponse>(),
                    CoachThirdPartyEvaluation = new List<EvaluationResponse>(),
                    SportsArenaSelfEvaluation = new List<EvaluationResponse>(),
                    SportsArenaThirdPartyEvaluation = new List<EvaluationResponse>(),
                    CategorySport = new List<CategoryResponse>(),
                    Position = new List<PositionResponse>()
                };
                if (_sport.SelfEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.SelfEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.SelfEvaluation.Add(evaluation);
                    }
                }
                if (_sport.ThirdPartyEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.ThirdPartyEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.ThirdPartyEvaluation.Add(evaluation);
                    }
                }
                if (_sport.RefereeSelfEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.RefereeSelfEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.RefereeSelfEvaluation.Add(evaluation);
                    }
                }
                if (_sport.RefereeThirdPartyEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.RefereeThirdPartyEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.RefereeThirdPartyEvaluation.Add(evaluation);
                    }
                }
                if (_sport.SpecialPlayerSelfEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.SpecialPlayerSelfEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.SpecialPlayerSelfEvaluation.Add(evaluation);
                    }
                }
                if (_sport.SpecialPlayerThirdPartyEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.SpecialPlayerThirdPartyEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.SpecialPlayerThirdPartyEvaluation.Add(evaluation);
                    }
                }
                if (_sport.CoachSelfEvaluation != null)
                {
                    if (_sport.CoachSelfEvaluation.Count > 0)
                    {
                        foreach (Evaluation item in _sport.CoachSelfEvaluation)
                        {
                            EvaluationResponse evaluation = new EvaluationResponse
                            {
                                Id = item.Id,
                                Group = item.Group,
                                Name = item.Name,
                                Description = item.Description,
                                MaximumValue = item.MaximumValue,
                                MinimumValue = item.MinimumValue
                            };
                            sportGet.CoachSelfEvaluation.Add(evaluation);
                        }
                    }
                }
                if (_sport.CoachThirdPartyEvaluation != null)
                {
                    if (_sport.CoachThirdPartyEvaluation.Count > 0)
                    {
                        foreach (Evaluation item in _sport.CoachThirdPartyEvaluation)
                        {
                            EvaluationResponse evaluation = new EvaluationResponse
                            {
                                Id = item.Id,
                                Group = item.Group,
                                Name = item.Name,
                                Description = item.Description,
                                MaximumValue = item.MaximumValue,
                                MinimumValue = item.MinimumValue
                            };
                            sportGet.CoachThirdPartyEvaluation.Add(evaluation);
                        }
                    }
                }
                if (_sport.SportsArenaSelfEvaluation != null)
                {
                    if (_sport.SportsArenaSelfEvaluation.Count > 0)
                    {
                        foreach (Evaluation item in _sport.SportsArenaSelfEvaluation)
                        {
                            EvaluationResponse evaluation = new EvaluationResponse
                            {
                                Id = item.Id,
                                Group = item.Group,
                                Name = item.Name,
                                Description = item.Description,
                                MaximumValue = item.MaximumValue,
                                MinimumValue = item.MinimumValue
                            };
                            sportGet.SportsArenaSelfEvaluation.Add(evaluation);
                        }
                    }
                }
                if (_sport.SportsArenaThirdPartyEvaluation != null)
                {
                    if (_sport.SportsArenaThirdPartyEvaluation.Count > 0)
                    {
                        foreach (Evaluation item in _sport.SportsArenaThirdPartyEvaluation)
                        {
                            EvaluationResponse evaluation = new EvaluationResponse
                            {
                                Id = item.Id,
                                Group = item.Group,
                                Name = item.Name,
                                Description = item.Description,
                                MaximumValue = item.MaximumValue,
                                MinimumValue = item.MinimumValue
                            };
                            sportGet.SportsArenaThirdPartyEvaluation.Add(evaluation);
                        }
                    }
                }
                if (_sport.CategorySport != null)
                {
                    if (_sport.CategorySport.Count > 0)
                    {
                        foreach (Category item in _sport.CategorySport)
                        {
                            CategoryResponse category = new CategoryResponse
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description
                            };
                            sportGet.CategorySport.Add(category);
                        }
                    }
                }
                if (_sport.Position != null)
                {
                    if (_sport.Position.Count > 0)
                    {
                        foreach (Position item in _sport.Position)
                        {
                            PositionResponse position = new PositionResponse
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description
                            };
                            sportGet.Position.Add(position);
                        }
                    }
                }
                sportResponse.Add(sportGet);
            }
            return sportResponse;
        }
        #endregion

        #region GetSportIdAsync
        public async Task<SportResponse> GetSportIdAsync(string id)
        {
            SportInformation? _sport = await _sportCollection.Find(r => r.Id == Guid.Parse(id)).FirstOrDefaultAsync();
            if (_sport == null)
                return null;
            SportResponse sportGet = new SportResponse
            {
                Id = _sport.Id,
                Name = _sport.Name,
                Description = _sport.Description,
                Status = _sport.Status,
                SelfEvaluation = new List<EvaluationResponse>(),
                ThirdPartyEvaluation = new List<EvaluationResponse>(),
                RefereeSelfEvaluation = new List<EvaluationResponse>(),
                RefereeThirdPartyEvaluation = new List<EvaluationResponse>(),
                SpecialPlayerSelfEvaluation = new List<EvaluationResponse>(),
                SpecialPlayerThirdPartyEvaluation = new List<EvaluationResponse>(),
                CoachSelfEvaluation = new List<EvaluationResponse>(),
                CoachThirdPartyEvaluation = new List<EvaluationResponse>(),
                SportsArenaSelfEvaluation = new List<EvaluationResponse>(),
                SportsArenaThirdPartyEvaluation = new List<EvaluationResponse>(),
                CategorySport = new List<CategoryResponse>(),
                Position = new List<PositionResponse>()
            };
            if (_sport.SelfEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.SelfEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.SelfEvaluation.Add(evaluation);
                }
            }
            if (_sport.ThirdPartyEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.ThirdPartyEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.ThirdPartyEvaluation.Add(evaluation);
                }
            }
            if (_sport.RefereeSelfEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.RefereeSelfEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.RefereeSelfEvaluation.Add(evaluation);
                }
            }
            if (_sport.RefereeThirdPartyEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.RefereeThirdPartyEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.RefereeThirdPartyEvaluation.Add(evaluation);
                }
            }
            if (_sport.SpecialPlayerSelfEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.SpecialPlayerSelfEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.SpecialPlayerSelfEvaluation.Add(evaluation);
                }
            }
            if (_sport.SpecialPlayerThirdPartyEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.SpecialPlayerThirdPartyEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.SpecialPlayerThirdPartyEvaluation.Add(evaluation);
                }
            }
            if (_sport.CoachSelfEvaluation != null)
            {
                if (_sport.CoachSelfEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.CoachSelfEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.CoachSelfEvaluation.Add(evaluation);
                    }
                }
            }
            if (_sport.CoachThirdPartyEvaluation != null)
            {
                if (_sport.CoachThirdPartyEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.CoachThirdPartyEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.CoachThirdPartyEvaluation.Add(evaluation);
                    }
                }
            }
            if (_sport.SportsArenaSelfEvaluation != null)
            {
                if (_sport.SportsArenaSelfEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.SportsArenaSelfEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.SportsArenaSelfEvaluation.Add(evaluation);
                    }
                }
            }
            if (_sport.SportsArenaThirdPartyEvaluation != null)
            {
                if (_sport.SportsArenaThirdPartyEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.SportsArenaThirdPartyEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.SportsArenaThirdPartyEvaluation.Add(evaluation);
                    }
                }
            }
            if (_sport.CategorySport != null)
            {
                if (_sport.CategorySport.Count > 0)
                {
                    foreach (Category item in _sport.CategorySport)
                    {
                        CategoryResponse category = new CategoryResponse
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Description = item.Description
                        };
                        sportGet.CategorySport.Add(category);
                    }
                }
            }
            if (_sport.Position != null)
            {
                if (_sport.Position.Count > 0)
                {
                    foreach (Position item in _sport.Position)
                    {
                        PositionResponse position = new PositionResponse
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Description = item.Description
                        };
                        sportGet.Position.Add(position);
                    }
                }
            }
            return sportGet;
        }
        #endregion

        #region GetSportNameAsync
        public async Task<SportResponse> GetSportNameAsync(string name)
        {
            SportInformation? _sport = await _sportCollection.Find(r => r.Name == name).FirstOrDefaultAsync();
            if (_sport == null)
                return null;
            SportResponse sportGet = new SportResponse
            {
                Id = _sport.Id,
                Name = _sport.Name,
                Description = _sport.Description,
                Status = _sport.Status,
                SelfEvaluation = new List<EvaluationResponse>(),
                ThirdPartyEvaluation = new List<EvaluationResponse>(),
                RefereeSelfEvaluation = new List<EvaluationResponse>(),
                RefereeThirdPartyEvaluation = new List<EvaluationResponse>(),
                SpecialPlayerSelfEvaluation = new List<EvaluationResponse>(),
                SpecialPlayerThirdPartyEvaluation = new List<EvaluationResponse>(),
                CoachSelfEvaluation = new List<EvaluationResponse>(),
                CoachThirdPartyEvaluation = new List<EvaluationResponse>(),
                SportsArenaSelfEvaluation = new List<EvaluationResponse>(),
                SportsArenaThirdPartyEvaluation = new List<EvaluationResponse>(),
                CategorySport = new List<CategoryResponse>(),
                Position = new List<PositionResponse>()
            };
            if (_sport.SelfEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.SelfEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.SelfEvaluation.Add(evaluation);
                }
            }
            if (_sport.ThirdPartyEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.ThirdPartyEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.ThirdPartyEvaluation.Add(evaluation);
                }
            }
            if (_sport.RefereeSelfEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.RefereeSelfEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.RefereeSelfEvaluation.Add(evaluation);
                }
            }
            if (_sport.RefereeThirdPartyEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.RefereeThirdPartyEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.RefereeThirdPartyEvaluation.Add(evaluation);
                }
            }
            if (_sport.SpecialPlayerSelfEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.SpecialPlayerSelfEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.SpecialPlayerSelfEvaluation.Add(evaluation);
                }
            }
            if (_sport.SpecialPlayerThirdPartyEvaluation.Count > 0)
            {
                foreach (Evaluation item in _sport.SpecialPlayerThirdPartyEvaluation)
                {
                    EvaluationResponse evaluation = new EvaluationResponse
                    {
                        Id = item.Id,
                        Group = item.Group,
                        Name = item.Name,
                        Description = item.Description,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    sportGet.SpecialPlayerThirdPartyEvaluation.Add(evaluation);
                }
            }
            if (_sport.CoachSelfEvaluation != null)
            {
                if (_sport.CoachSelfEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.CoachSelfEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.CoachSelfEvaluation.Add(evaluation);
                    }
                }
            }
            if (_sport.CoachThirdPartyEvaluation != null)
            {
                if (_sport.CoachThirdPartyEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.CoachThirdPartyEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.CoachThirdPartyEvaluation.Add(evaluation);
                    }
                }
            }
            if (_sport.SportsArenaSelfEvaluation != null)
            {
                if (_sport.SportsArenaSelfEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.SportsArenaSelfEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.SportsArenaSelfEvaluation.Add(evaluation);
                    }
                }
            }
            if (_sport.SportsArenaThirdPartyEvaluation != null)
            {
                if (_sport.SportsArenaThirdPartyEvaluation.Count > 0)
                {
                    foreach (Evaluation item in _sport.SportsArenaThirdPartyEvaluation)
                    {
                        EvaluationResponse evaluation = new EvaluationResponse
                        {
                            Id = item.Id,
                            Group = item.Group,
                            Name = item.Name,
                            Description = item.Description,
                            MaximumValue = item.MaximumValue,
                            MinimumValue = item.MinimumValue
                        };
                        sportGet.SportsArenaThirdPartyEvaluation.Add(evaluation);
                    }
                }
            }
            if (_sport.CategorySport != null)
            {
                if (_sport.CategorySport.Count > 0)
                {
                    foreach (Category item in _sport.CategorySport)
                    {
                        CategoryResponse category = new CategoryResponse
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Description = item.Description
                        };
                        sportGet.CategorySport.Add(category);
                    }
                }
            }
            if (_sport.Position != null)
            {
                if (_sport.Position.Count > 0)
                {
                    foreach (Position item in _sport.Position)
                    {
                        PositionResponse position = new PositionResponse
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Description = item.Description
                        };
                        sportGet.Position.Add(position);
                    }
                }
            }
            return sportGet;
        }
        #endregion

        #region CreateSportAsync
        public async Task CreateSportAsync(SportInformationRequest sport)
        {
            SportInformation _sport = new SportInformation
            {
                Id = Guid.NewGuid(),
                Description = sport.Description,
                Name = sport.Name,
                Status = sport.Status,
                SelfEvaluation = new List<Evaluation>(),
                ThirdPartyEvaluation = new List<Evaluation>(),
                RefereeSelfEvaluation = new List<Evaluation>(),
                RefereeThirdPartyEvaluation = new List<Evaluation>(),
                SpecialPlayerSelfEvaluation = new List<Evaluation>(),
                SpecialPlayerThirdPartyEvaluation = new List<Evaluation>(),
                CoachSelfEvaluation = new List<Evaluation>(),
                CoachThirdPartyEvaluation = new List<Evaluation>(),
                SportsArenaSelfEvaluation = new List<Evaluation>(),
                SportsArenaThirdPartyEvaluation = new List<Evaluation>(),
                CategorySport = new List<Category>(),
                Position = new List<Position>()
            };
            if (sport.SelfEvaluation.Count > 0)
            {
                foreach (var item in sport.SelfEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.SelfEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.ThirdPartyEvaluation.Count > 0)
            {
                foreach (var item in sport.ThirdPartyEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.ThirdPartyEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.RefereeSelfEvaluation.Count > 0)
            {
                foreach (var item in sport.RefereeSelfEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.RefereeSelfEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.RefereeThirdPartyEvaluation.Count > 0)
            {
                foreach (var item in sport.RefereeThirdPartyEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.RefereeThirdPartyEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.SpecialPlayerSelfEvaluation.Count > 0)
            {
                foreach (var item in sport.SpecialPlayerSelfEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.SpecialPlayerSelfEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.SpecialPlayerThirdPartyEvaluation.Count > 0)
            {
                foreach (var item in sport.SpecialPlayerThirdPartyEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.SpecialPlayerThirdPartyEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.CoachSelfEvaluation.Count > 0)
            {
                foreach (var item in sport.CoachSelfEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.CoachSelfEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.CoachThirdPartyEvaluation.Count > 0)
            {
                foreach (var item in sport.CoachThirdPartyEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.CoachThirdPartyEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.SportsArenaSelfEvaluation.Count > 0)
            {
                foreach (var item in sport.SportsArenaSelfEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.SportsArenaSelfEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.SportsArenaThirdPartyEvaluation .Count > 0)
            {
                foreach (var item in sport.SportsArenaThirdPartyEvaluation)
                {
                    Evaluation evaluationRequest = new Evaluation()
                    {
                        Id = Guid.NewGuid(),
                        Group = item.Group,
                        Description = item.Description,
                        Name = item.Name,
                        MaximumValue = item.MaximumValue,
                        MinimumValue = item.MinimumValue
                    };
                    _sport.SportsArenaThirdPartyEvaluation.Add(evaluationRequest);
                }
            }
            if (sport.Category.Count > 0)
            {
                foreach (var item in sport.Category)
                {
                    Category categoryRequest = new Category()
                    {
                        Id = Guid.NewGuid(),
                        Description = item.Description,
                        Name = item.Name
                    };
                    _sport.CategorySport.Add(categoryRequest);
                }
            }
            if (sport.Position.Count > 0)
            {
                foreach (var item in sport.Position)
                {
                    Position positionRequest = new Position()
                    {
                        Id = Guid.NewGuid(),
                        Description = item.Description,
                        Name = item.Name
                    };
                    _sport.Position.Add(positionRequest);
                }
            }
            await _sportCollection.InsertOneAsync(_sport);
        }
        #endregion

        #region UpdateStatusSportAsync
        public async Task<bool> UpdateStatusSportAsync(Guid id, bool status)
        {
            var filter = Builders<SportInformation>.Filter.Eq(m => m.Id, id);
            var update = Builders<SportInformation>.Update.Set(m => m.Status, status);
            var result = await _sportCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region AddSportDetailAsync
        public async Task<bool> AddSportDetailAsync(Guid id, EnumEvaluation type, EvaluationRequest newEvaluation)
        {
            Evaluation evaluation = new Evaluation()
            {
                Id = Guid.NewGuid(),
                Group = newEvaluation.Group,
                Name = newEvaluation.Name,
                Description = newEvaluation.Description,
                MaximumValue = newEvaluation.MaximumValue,
                MinimumValue = newEvaluation.MinimumValue
            };

            UpdateDefinition<SportInformation> update;
            switch (type)
            {
                case EnumEvaluation.SelfEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.SelfEvaluation, evaluation);
                    break;
                case EnumEvaluation.ThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.ThirdPartyEvaluation, evaluation);
                    break;
                case EnumEvaluation.RefereeSelfEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.RefereeSelfEvaluation, evaluation);
                    break;
                case EnumEvaluation.RefereeThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.RefereeThirdPartyEvaluation, evaluation);
                    break;
                case EnumEvaluation.SpecialPlayerSelfEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.SpecialPlayerSelfEvaluation, evaluation);
                    break;
                case EnumEvaluation.SpecialPlayerThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.SpecialPlayerThirdPartyEvaluation, evaluation);
                    break;
                case EnumEvaluation.CoachSelfEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.CoachSelfEvaluation, evaluation);
                    break;
                case EnumEvaluation.CoachThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.CoachThirdPartyEvaluation, evaluation);
                    break;
                case EnumEvaluation.SportsArenaSelfEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.SportsArenaSelfEvaluation, evaluation);
                    break;
                case EnumEvaluation.SportsArenaThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.Push(s => s.SportsArenaThirdPartyEvaluation, evaluation);
                    break;
                default:
                    update = null;
                    break;
            }

            if (update == null)
            {
                return false;
            }
            var result = await _sportCollection.UpdateOneAsync(s => s.Id == id, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region UpdateSportDetailAsync
        public async Task<bool> UpdateSportDetailAsync(Guid id, EnumEvaluation type, Guid evaluationId, EvaluationRequest newEvaluation)
        {
            Evaluation evaluation = new Evaluation()
            {
                Id = evaluationId,
                Group = newEvaluation.Group,
                Name = newEvaluation.Name,
                Description = newEvaluation.Description,
                MaximumValue = newEvaluation.MaximumValue,
                MinimumValue = newEvaluation.MinimumValue
            };

            UpdateDefinition<SportInformation> update;
            FilterDefinition<SportInformation> filter;
            switch (type)
            {
                case EnumEvaluation.SelfEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.SelfEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("selfEvaluation.$", evaluation);
                    break;
                case EnumEvaluation.ThirdPartyEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.ThirdPartyEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("thirdPartyEvaluation.$", evaluation);
                    break;
                case EnumEvaluation.RefereeSelfEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.RefereeSelfEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("refereeSelfEvaluation.$", evaluation);
                    break;
                case EnumEvaluation.RefereeThirdPartyEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.RefereeThirdPartyEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("refereeThirdPartyEvaluation.$", evaluation);
                    break;
                case EnumEvaluation.SpecialPlayerSelfEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.SpecialPlayerSelfEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("specialPlayerSelfEvaluation.$", evaluation);
                    break;
                case EnumEvaluation.SpecialPlayerThirdPartyEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.SpecialPlayerThirdPartyEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("specialPlayerThirdPartyEvaluation.$", evaluation);
                    break;
                case EnumEvaluation.CoachSelfEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.CoachSelfEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("coachSelfEvaluation.$", evaluation);
                    break;
                case EnumEvaluation.CoachThirdPartyEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.CoachThirdPartyEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("coachThirdPartyEvaluation.$", evaluation);
                    break;

                case EnumEvaluation.SportsArenaSelfEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.SportsArenaSelfEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("sportsArenaSelfEvaluation.$", evaluation);
                    break;
                case EnumEvaluation.SportsArenaThirdPartyEvaluation:
                    filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                Builders<SportInformation>.Filter.ElemMatch(s => s.SportsArenaThirdPartyEvaluation, e => e.Id == evaluationId));
                    update = Builders<SportInformation>.Update.Set("sportsArenaThirdPartyEvaluation.$", evaluation);
                    break;
                default:
                    update = null;
                    filter = null;
                    break;
            }
            if (update == null)
            {
                return false;
            }
            var result = await _sportCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region DeleteSportDetailAsync
        public async Task<bool> DeleteSportDetailAsync(Guid id, EnumEvaluation type, Guid evaluationId)
        {
            UpdateDefinition<SportInformation> update;
            switch (type)
            {
                case EnumEvaluation.SelfEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.SelfEvaluation, e => e.Id == evaluationId);
                    break;
                case EnumEvaluation.ThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.ThirdPartyEvaluation, e => e.Id == evaluationId);
                    break;
                case EnumEvaluation.RefereeSelfEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.RefereeSelfEvaluation, e => e.Id == evaluationId);
                    break;
                case EnumEvaluation.RefereeThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.RefereeThirdPartyEvaluation, e => e.Id == evaluationId);
                    break;
                case EnumEvaluation.SpecialPlayerSelfEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.SpecialPlayerSelfEvaluation, e => e.Id == evaluationId);
                    break;
                case EnumEvaluation.SpecialPlayerThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.SpecialPlayerThirdPartyEvaluation, e => e.Id == evaluationId);
                    break;
                case EnumEvaluation.CoachSelfEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.CoachSelfEvaluation, e => e.Id == evaluationId);
                    break;
                case EnumEvaluation.CoachThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.CoachThirdPartyEvaluation, e => e.Id == evaluationId);
                    break;
                case EnumEvaluation.SportsArenaSelfEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.SportsArenaSelfEvaluation, e => e.Id == evaluationId);
                    break;
                case EnumEvaluation.SportsArenaThirdPartyEvaluation:
                    update = Builders<SportInformation>.Update.PullFilter(s => s.SportsArenaThirdPartyEvaluation, e => e.Id == evaluationId);
                    break;
                default:
                    update = null;
                    break;
            }

            if (update == null)
            {
                return false;
            }

            var result = await _sportCollection.UpdateOneAsync(s => s.Id == id, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region AddSportCategoryAsync
        public async Task<bool> AddSportCategoryAsync(Guid id, CategoryRequest newCategory)
        {
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = newCategory.Name,
                Description = newCategory.Description
            };

            UpdateDefinition<SportInformation> update = Builders<SportInformation>.Update.Push(s => s.CategorySport, category);

            var result = await _sportCollection.UpdateOneAsync(s => s.Id == id, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region UpdateSportCategoryAsync
        public async Task<bool> UpdateSportCategoryAsync(Guid id, Guid categoryId, CategoryRequest newCategory)
        {
            Category category = new Category()
            {
                Id = categoryId,
                Name = newCategory.Name,
                Description = newCategory.Description
            };
            
            FilterDefinition<SportInformation> filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                                            Builders<SportInformation>.Filter.ElemMatch(s => s.CategorySport, e => e.Id == categoryId));

            UpdateDefinition<SportInformation> update = Builders<SportInformation>.Update.Set("categorySport.$", category);
            
            var result = await _sportCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region DeleteSportCategoryAsync
        public async Task<bool> DeleteSportCategoryAsync(Guid id, Guid categoryId)
        {
            UpdateDefinition<SportInformation> update = Builders<SportInformation>.Update.PullFilter(s => s.CategorySport, e => e.Id == categoryId);
            var result = await _sportCollection.UpdateOneAsync(s => s.Id == id, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region AddPositionAsync
        public async Task<bool> AddPositionAsync(Guid id, PositionRequest newPosition)
        {
            Position position = new Position()
            {
                Id = Guid.NewGuid(),
                Name = newPosition.Name,
                Description = newPosition.Description
            };

            UpdateDefinition<SportInformation> update = Builders<SportInformation>.Update.Push(s => s.Position, position);

            var result = await _sportCollection.UpdateOneAsync(s => s.Id == id, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region UpdatePositionAsync
        public async Task<bool> UpdatePositionAsync(Guid id, Guid positionId, PositionRequest newPosition)
        {
            Position position = new Position()
            {
                Id = positionId,
                Name = newPosition.Name,
                Description = newPosition.Description
            };

            FilterDefinition<SportInformation> filter = Builders<SportInformation>.Filter.And(Builders<SportInformation>.Filter.Eq(s => s.Id, id),
                                                            Builders<SportInformation>.Filter.ElemMatch(s => s.Position, e => e.Id == positionId));

            UpdateDefinition<SportInformation> update = Builders<SportInformation>.Update.Set("position.$", position);

            var result = await _sportCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
        #endregion

        #region DeletePositionAsync
        public async Task<bool> DeletePositionAsync(Guid id, Guid positionId)
        {
            UpdateDefinition<SportInformation> update = Builders<SportInformation>.Update.PullFilter(s => s.Position, e => e.Id == positionId);
            var result = await _sportCollection.UpdateOneAsync(s => s.Id == id, update);
            return result.ModifiedCount > 0;
        }
        #endregion
    }
}
