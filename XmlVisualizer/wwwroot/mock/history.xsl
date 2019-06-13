<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0">
	<xsl:key name="clubLeague" match="league" use="@league_id"/>
	<xsl:key name="teamClub" match="club" use="@club_id"/>
    <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:template match="/">
		<xsl:element name="uefaCompetitionsReport">
			<xsl:element name="uefaLeagues">
				<xsl:apply-templates select="history/finals"/>
			</xsl:element>
			<xsl:element name="uefaCompetitionsSummary">
			
				<!-- srednia ilosc ludzi na stadionie w zaleznosci od typu rozgrywek -->
				<!-- <xsl:for-each select="history/finals/matches"> -->
					<!-- <xsl:element name="AvgFrequencySortedCompetitions"> -->
						<!-- <xsl:attribute name="nameOfCompetition"> -->
							<!-- <xsl:value-of select="@matches_id"/> -->
						<!-- </xsl:attribute> -->
						<!-- <xsl:element name="value"> -->
							<!-- <xsl:value-of select="floor(avg(match/info/frequency))" /> -->
						<!-- </xsl:element> -->
					<!-- </xsl:element> -->
				<!-- </xsl:for-each> -->
				
				<!-- mecze, w ktorych odbyly sie rzuty karne -->
				<xsl:for-each select="history/finals/matches">
					<xsl:element name="OnlyPenaltyMatches">
						<xsl:attribute name="nameOfCompetition">
							<xsl:value-of select="@matches_id"/>
						</xsl:attribute>
						<xsl:for-each select="match/goals[@penalties='true']">
							<xsl:element name="match">
								<xsl:element name="homeTeam">
									<xsl:value-of select="key('teamClub', ../@homeTeam)/name"/>
								</xsl:element>
								<xsl:element name="awayTeam">
									<xsl:value-of select="key('teamClub', ../@awayTeam)/name"/>
								</xsl:element>
								<xsl:element name="date">
									<xsl:value-of select="../info/date" />
								</xsl:element>
							</xsl:element>
						</xsl:for-each>
						</xsl:element>
				</xsl:for-each>
				
				<!-- mecz z najwieksza oraz z najmniejsza frekwencja dla danych rozgrywek -->
				<!-- <xsl:for-each select="history/finals/matches"> -->
					<!-- <xsl:element name="MostAndLeastFrequentMatch"> -->
						<!-- <xsl:attribute name="nameOfCompetition"> -->
							<!-- <xsl:value-of select="@matches_id"/> -->
						<!-- </xsl:attribute> -->
						<!-- <xsl:variable name="maxFrequency" select="max(match/info/frequency)" /> -->
						<!-- <xsl:variable name="minFrequency" select="min(match/info/frequency)" /> -->
						<!-- <xsl:for-each select="match"> -->
							<!-- <xsl:if test="$maxFrequency = info/frequency"> -->
								<!-- <xsl:element name="MostFrequentMatch"> -->
									<!-- <xsl:element name="homeTeam"> -->
										<!-- <xsl:value-of select="key('teamClub', @homeTeam)/name"/> -->
									<!-- </xsl:element> -->
									<!-- <xsl:element name="awayTeam"> -->
										<!-- <xsl:value-of select="key('teamClub', @awayTeam)/name"/> -->
									<!-- </xsl:element> -->
									<!-- <xsl:element name="date"> -->
										<!-- <xsl:value-of select="info/date" /> -->
									<!-- </xsl:element> -->
									<!-- <xsl:element name="frequency"> -->
										<!-- <xsl:value-of select="$maxFrequency" /> -->
									<!-- </xsl:element> -->
								<!-- </xsl:element> -->
							<!-- </xsl:if> -->
							<!-- <xsl:if test="$minFrequency = info/frequency"> -->
								<!-- <xsl:element name="LeastFrequentMatch"> -->
									<!-- <xsl:element name="homeTeam"> -->
										<!-- <xsl:value-of select="key('teamClub', @homeTeam)/name"/> -->
									<!-- </xsl:element> -->
									<!-- <xsl:element name="awayTeam"> -->
										<!-- <xsl:value-of select="key('teamClub', @awayTeam)/name"/> -->
									<!-- </xsl:element> -->
									<!-- <xsl:element name="date"> -->
										<!-- <xsl:value-of select="info/date"/> -->
									<!-- </xsl:element> -->
									<!-- <xsl:element name="frequency"> -->
										<!-- <xsl:value-of select="$minFrequency" /> -->
									<!-- </xsl:element> -->
								<!-- </xsl:element> -->
							<!-- </xsl:if> -->
						<!-- </xsl:for-each> -->
					<!-- </xsl:element> -->
				<!-- </xsl:for-each> -->

				<!-- laczna liczba bramek w rozgrywkach w zaleznosci od ich rodzaju -->
				<xsl:for-each select="history/finals/matches">
					<xsl:element name="SumOfGoalsInCompetition">
						<xsl:attribute name="nameOfCompetition">
							<xsl:value-of select="@matches_id"/>
						</xsl:attribute>
						<xsl:element name="numberOfGoals">
								<xsl:value-of select="sum(match/goals/normalTime/result)"/>
							</xsl:element>
						</xsl:element>
				</xsl:for-each>
				
				<!-- Podsumowanie -->
				
				<!-- laczna suma elementow (meczy), suma elementow w poszczegolnych rozgrywkach -->
				<xsl:element name="EndSummary">
					<xsl:for-each select="history/finals">
						<xsl:element name="numberOfAllMatches">
							<xsl:value-of select="count(matches/match)" />
						</xsl:element>
						<xsl:element name="numberOfCompetitions">
							<xsl:value-of select="count(matches)" />
						</xsl:element>
						<xsl:for-each select="matches">
							<xsl:if test="@matches_id='championsLeague'">
								<xsl:element name="championsLeagueStats">
									<xsl:element name="numberOfMatches">
										<xsl:value-of select="count(match)" />
									</xsl:element>
									<xsl:element name="costOfTickets">
										<xsl:attribute name="currency">PLN</xsl:attribute>
										<xsl:element name="sumCost">
											<xsl:value-of select="sum(match/info/pricePerTicket/payment[@currency='PLN'])" />
										</xsl:element>
										<xsl:element name="vatCost">
											<xsl:value-of select="floor((sum(match/info/pricePerTicket/payment[@currency='PLN']))*0.23)" />
										</xsl:element>
									</xsl:element>
								</xsl:element>
							</xsl:if>
							<xsl:if test="@matches_id='europaLeague'">
							<xsl:element name="europaLeagueStats">
								<xsl:element name="numberOfMatches">
									<xsl:value-of select="count(match)" />
								</xsl:element>
								<xsl:element name="costOfTickets">
										<xsl:attribute name="currency">PLN</xsl:attribute>
										<xsl:element name="sumCost">
											<xsl:value-of select="sum(match/info/pricePerTicket/payment[@currency='PLN'])" />
										</xsl:element>
										<xsl:element name="vatCost">
											<xsl:value-of select="floor((sum(match/info/pricePerTicket/payment[@currency='PLN']))*0.23)" />
										</xsl:element>
									</xsl:element>
							</xsl:element>
							</xsl:if>
						</xsl:for-each>
					</xsl:for-each>
				</xsl:element>
				

				
			</xsl:element>
		</xsl:element>
	</xsl:template>
	<xsl:template match="history/finals">
	
		<xsl:for-each select="matches">
			<xsl:element name="uefaLeague">
				<xsl:element name="description">
					<xsl:value-of select="description"/>
				</xsl:element>
				
				<xsl:for-each select="match">
					<xsl:element name="singleMatch">
						<xsl:element name="homeTeamClub">
							<xsl:value-of select="key('teamClub',@homeTeam)/name"/>
						</xsl:element>
						<xsl:element name="awayTeamClub">
							<xsl:value-of select="key('teamClub',@awayTeam)/name"/>
						</xsl:element>
						
						<xsl:element name="goalsInfo">
							<xsl:attribute name="penalties">
								<xsl:value-of select="goals/@penalties"/>
							</xsl:attribute>
							
							<xsl:element name="normalTime">
								<xsl:element name="resultHomeTeam">
									<xsl:value-of select="goals/normalTime/result[@score='home']"/>
								</xsl:element>
								<xsl:element name="resultAwayTeam">
									<xsl:value-of select="goals/normalTime/result[@score='away']"/>
								</xsl:element>
							</xsl:element>
							
							<xsl:choose>
								<xsl:when test="goals/@penalties='true'">
								
									<xsl:element name="penalties">
										<xsl:element name="resultHomeTeam">
											<xsl:value-of select="goals/penalties/result[@score='home']"/>
										</xsl:element>
										<xsl:element name="resultAwayTeam">
											<xsl:value-of select="goals/penalties/result[@score='away']"/>
										</xsl:element>
									</xsl:element>
								</xsl:when>
								<xsl:otherwise />
							</xsl:choose>
						</xsl:element>
						
						<xsl:element name="matchInfo">
							<xsl:element name="stadium">
								<xsl:value-of select="info/stadium"/>
							</xsl:element>
							<xsl:element name="date">
								<xsl:value-of select="info/date"/>
							</xsl:element>
							<xsl:element name="frequency">
								<xsl:value-of select="info/frequency"/>
							</xsl:element>
							<xsl:element name="pricePerTicket">
								<xsl:attribute name="currency">
									<xsl:value-of select="info/pricePerTicket/payment[@currency='PLN']/@currency"/>
								</xsl:attribute>
								<xsl:value-of select="info/pricePerTicket/payment[@currency='PLN']"/>
							</xsl:element>
						</xsl:element>
						
					</xsl:element>
				</xsl:for-each>
			</xsl:element>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>