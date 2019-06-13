<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xhtml" version="1.0" encoding="UTF-8" indent="yes"/>
    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
            <head>
				<meta charset="UTF-8" />
                <title>History of UEFA Champions League and Europa League matches between the last 11 years</title>
            </head>
            <body>
                <h1 align="center">Matches data statistics</h1>
				<!-- <table border="10px" align="center" bgcolor="#99ccff" style="text-align: center; color:#black; margin-top: 30px;"> -->
					<!-- <tr> -->
						<!-- <th colspan="2">Average frequency at matches for each competition</th> -->
                    <!-- </tr> -->
					<!-- <tr> -->
						<!-- <th>Average frequency</th> -->
						<!-- <th>Name of competition</th> -->
                    <!-- </tr> -->
                    <!-- <xsl:for-each select="uefaCompetitionsReport/uefaCompetitionsSummary/AvgFrequencySortedCompetitions"> -->
                        <!-- <xsl:choose> -->
							<!-- <xsl:when test="@nameOfCompetition='championsLeague'"> -->
								<!-- <tr> -->
									<!-- <td><xsl:value-of select="value"/></td> -->
									<!-- <td>Champions League</td> -->
								<!-- </tr> -->
							<!-- </xsl:when> -->
							<!-- <xsl:otherwise> -->
								<!-- <tr> -->
									<!-- <td><xsl:value-of select="value"/></td> -->
									<!-- <td>Europa League</td> -->
								<!-- </tr> -->
							<!-- </xsl:otherwise> -->
						<!-- </xsl:choose> -->
					<!-- </xsl:for-each> -->
				<!-- </table> -->
				
				<table border="10px" align="center" bgcolor="#99ccff" style="text-align: center; color:#black; margin-top: 30px;">
                    <tr>
                        <th colspan="4">Matches with penalties for each competition </th>
                    </tr>
					<tr>
						<th>Home team</th>
						<th>Away team</th>
						<th>Date</th>
						<th>Name of Competition</th>
                    </tr>
                    <xsl:for-each select="uefaCompetitionsReport/uefaCompetitionsSummary/OnlyPenaltyMatches">
						<xsl:for-each select="match">
							<tr>
								<td><xsl:value-of select="homeTeam"/></td>
								<td><xsl:value-of select="awayTeam"/></td>
								<td><xsl:value-of select="date"/></td>
                        <xsl:choose>
							<xsl:when test="../@nameOfCompetition='championsLeague'">
								<td>Champions League</td>
							</xsl:when>
							<xsl:otherwise>
								<td>Europa League</td>
							</xsl:otherwise>
						</xsl:choose>
							</tr>
						</xsl:for-each>
					</xsl:for-each>
				</table>
				
				<!-- <table border="10px" align="center" bgcolor="#99ccff" style="text-align: center; color:#black; margin-top: 30px;"> -->
                    <!-- <tr> -->
                        <!-- <th colspan="5">Matches with most and least frequency for each competition </th> -->
                    <!-- </tr> -->
					<!-- <tr> -->
						<!-- <th>Home team</th> -->
						<!-- <th>Away team</th> -->
						<!-- <th>Date</th> -->
						<!-- <th>Frequency</th> -->
						<!-- <th>Name of Competition</th> -->
                    <!-- </tr> -->
					<!-- <xsl:for-each select="//MostFrequentMatch | //LeastFrequentMatch"> -->
							<!-- <tr> -->
								<!-- <td><xsl:value-of select="homeTeam"/></td> -->
								<!-- <td><xsl:value-of select="awayTeam"/></td> -->
								<!-- <td><xsl:value-of select="date"/></td> -->
								<!-- <td><xsl:value-of select="frequency"/></td> -->
                        <!-- <xsl:choose> -->
							<!-- <xsl:when test="../@nameOfCompetition='championsLeague'"> -->
								<!-- <td>Champions League</td> -->
							<!-- </xsl:when> -->
							<!-- <xsl:otherwise> -->
								<!-- <td>Europa League</td> -->
							<!-- </xsl:otherwise> -->
						<!-- </xsl:choose> -->
							<!-- </tr> -->
					<!-- </xsl:for-each> -->
				<!-- </table> -->
				
				<table border="10px" align="center" bgcolor="#99ccff" style="text-align: center; color:#black; margin-top: 30px;">
					<tr>
						<th colspan="2">Sum of goals scored in all matches for each competiton</th>
                    </tr>
					<tr>
						<th>Sum of goals</th>
						<th>Name of competition</th>
                    </tr>
                    <xsl:for-each select="uefaCompetitionsReport/uefaCompetitionsSummary/SumOfGoalsInCompetition">
                        <xsl:choose>
							<xsl:when test="@nameOfCompetition='championsLeague'">
								<tr>
									<td><xsl:value-of select="numberOfGoals"/></td>
									<td>Champions League</td>
								</tr>
							</xsl:when>
							<xsl:otherwise>
								<tr>
									<td><xsl:value-of select="numberOfGoals"/></td>
									<td>Europa League</td>
								</tr>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</table>
				
				<table border="10px" align="center" bgcolor="#99ccff" style="text-align: center; color:#black; margin-top: 30px;">
					<tr>
						<th colspan="2">Number of all matches and number of competions</th>
                    </tr>
					<tr>
						<th>Number of matches</th>
						<th>Number of competitions</th>
                    </tr>
					<tr>
						<td><xsl:value-of select="//numberOfAllMatches"/></td>
						<td><xsl:value-of select="//numberOfCompetitions"/></td>
					</tr>
				</table>
				
				<table border="10px" align="center" bgcolor="#99ccff" style="text-align: center; color:#black; margin-top: 30px;">
					<tr>
						<th colspan="3">Champions League specified statistics</th>
                    </tr>
					<tr>
						<th>Number of matches</th>
						<th>Cost of all tickets with VAT tax</th>
						<th>Sum cost of VAT tax for all matches</th>
					</tr>
					<xsl:for-each select="uefaCompetitionsReport/uefaCompetitionsSummary/EndSummary">
						<tr>
							<td><xsl:value-of select="championsLeagueStats/numberOfMatches"/></td>
							<td><xsl:value-of select="concat(championsLeagueStats/costOfTickets/sumCost, ' ', championsLeagueStats/costOfTickets/@currency)"/></td>
							<td><xsl:value-of select="concat(championsLeagueStats/costOfTickets/vatCost, ' ', championsLeagueStats/costOfTickets/@currency)"/></td>
						</tr>
					</xsl:for-each>
				</table>
				
				<table border="10px" align="center" bgcolor="#99ccff" style="text-align: center; color:#black; margin-top: 30px;">
					<tr>
						<th colspan="3">Europa League specified statistics</th>
                    </tr>
					<tr>
						<th>Number of matches</th>
						<th>Cost of all tickets with VAT tax</th>
						<th>Sum cost of VAT tax for all matches</th>
					</tr>
					<xsl:for-each select="uefaCompetitionsReport/uefaCompetitionsSummary/EndSummary">
						<tr>
							<td><xsl:value-of select="championsLeagueStats/numberOfMatches"/></td>
							<td><xsl:value-of select="concat(europaLeagueStats/costOfTickets/sumCost,' ',europaLeagueStats/costOfTickets/@currency)"/></td>
							<td><xsl:value-of select="concat(europaLeagueStats/costOfTickets/vatCost,' ',europaLeagueStats/costOfTickets/@currency)"/></td>
						</tr>
					</xsl:for-each>
				</table>
				
                <h1 align="center">Matches</h1>

                <table border="10px" align="center" bgcolor="#99ccff" style="text-align: center; color:#black; margin-top: 30px;">
                    <xsl:for-each select="uefaCompetitionsReport/uefaLeagues/uefaLeague">
                        <tr>
                            <th colspan="12"><xsl:value-of select="description"/></th>
                        </tr>
                        <tr>
                            <th>Home  league</th>
                            <th>Home </th>
                            <th>Away</th>
							 <th>Away  league</th>
                            <th>Home score</th>
                            <th>Away score</th>
                            <th>Home penalties</th>
                            <th>Away penalties</th>
                            <th>Date</th>
                            <th>Stadium</th>
                            <th>Frequency</th>
                            <th>Ticket price (PLN)</th>
                        </tr>
                        <xsl:for-each select="singleMatch">
                            <!-- <xsl:sort select="matchInfo/frequency" order="ascending"/> -->
                            <tr>
                                <td><xsl:value-of select="homeTeamLeague"/></td>
                                <td><xsl:value-of select="homeTeamClub" /></td>
                                <td><xsl:value-of select="awayTeamClub" /></td>
                                <td><xsl:value-of select="awayTeamLeague" /></td>
                                <td><xsl:value-of select="goalsInfo/normalTime/resultHomeTeam" /></td>
                                <td><xsl:value-of select="goalsInfo/normalTime/resultAwayTeam" /></td>
								<xsl:choose>
									<xsl:when test="goalsInfo[@penalties='true']">
										<td><xsl:value-of select="goalsInfo/penalties/resultHomeTeam"/></td>
										<td><xsl:value-of select="goalsInfo/penalties/resultAwayTeam"/></td>
									</xsl:when>
								<xsl:otherwise>
									<td>-</td>
									<td>-</td>
								</xsl:otherwise>
								</xsl:choose>
								<td><xsl:value-of select="matchInfo/date"/></td>
                                <td><xsl:value-of select="matchInfo/stadium" /></td>
                                <td><xsl:value-of select="matchInfo/frequency" /></td>
                                <td><xsl:value-of select="matchInfo/pricePerTicket" /></td>
                            </tr>
                        </xsl:for-each>
					</xsl:for-each>
                </table>
				
				
				</body>
			</html>
		</xsl:template>
	</xsl:stylesheet>