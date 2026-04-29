using System;

namespace ClinicFlow.Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(Guid userId);
    string GenerateRefreshToken();
}
